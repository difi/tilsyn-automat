using Difi.Sjalvdeklaration.Shared;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.IdPorten;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Difi.Sjalvdeklaration.wwwroot.Pages
{
    public class LoginHandlerModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly ApiHttpClient apiHttpClient;

        public string Pid { get; set; }

        public string Sub { get; set; }

        public List<RoleItem> RoleList { get; set; }

        public LoginHandlerModel(IConfiguration configuration, ApiHttpClient apiHttpClient)
        {
            this.configuration = configuration;
            this.apiHttpClient = apiHttpClient;
        }

        public void OnGet()
        {
            var code = Request.Query["code"];
            var key = (configuration["IdPorten:ClientId"] + ":" + configuration["IdPorten:Secret"]).AsBase64();
            var stringContent = new StringContent("grant_type=authorization_code&redirect_uri=" + configuration["IdPorten:RedirectUrl"] + "&code=" + code, Encoding.UTF8, "application/x-www-form-urlencoded");

            var result = apiHttpClient.PostWithAuthorization<IdPortenRootObject>("/token", "Basic", key, stringContent).Result;

            var jwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().ReadJwtToken(result.id_token);

            if (jwtSecurityToken.Payload["nonce"].ToString() == configuration["IdPorten:Nonce"])
            {
                Pid = jwtSecurityToken.Payload["pid"].ToString();
                Sub = jwtSecurityToken.Payload["sub"].ToString();

                var userExists = apiHttpClient.Get<bool>("/api/User/Exists/" + Sub).Result;

                if (!userExists)
                {
                    var userItemCreate = new UserItem
                    {
                        IdPortenSub = Sub,
                        SocialSecurityNumber = Pid,
                        Id = Guid.NewGuid(),
                        Name = "Okänd"
                    };

                    var status = apiHttpClient.Post<bool>("/api/User/Add", userItemCreate);
                }

                var userItem = apiHttpClient.Get<UserItem>("/api/User/Get/" + Sub).Result;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userItem.IdPortenSub),
                    new Claim(ClaimTypes.Name, userItem.Name + ""),
                    new Claim(ClaimTypes.Email, userItem.Email + ""),
                    new Claim(ClaimTypes.OtherPhone, userItem.Phone + ""),
                    new Claim(ClaimTypes.DateOfBirth, userItem.SocialSecurityNumber + ""),
                };

                claims.AddRange(userItem.RoleList.Select(userRole => new Claim(ClaimTypes.Role, userRole.RoleItem.Name)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                if (userItem.RoleList.Any(x => x.RoleItem.Name == "Admin") || userItem.RoleList.Any(x => x.RoleItem.Name == "Saksbehandlare"))
                {
                    Response.Redirect("/Admin/DeclarationList");
                }
                else
                {
                    Response.Redirect(userItem.CompanyList.Any() ? "/Declaration/DeclarationList" : "/Declaration/CompanyLink");
                }
            }
        }
    }
}