using System.Linq;
using System.Security.Claims;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.wwwroot.Pages
{
    public class LogoutHandlerModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogoutHandlerModel(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IErrorHandler errorHandler)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.errorHandler = errorHandler;
        }

        public void OnGet(string what)
        {
            if (what == "logout")
            {
                var tokenClaim = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Hash);

                if (tokenClaim != null)
                {
                    Response.Redirect(configuration["IdPorten:BaseUrl"] + "/endsession?id_token_hint=" + tokenClaim.Value + "&post_logout_redirect_uri=" + configuration["IdPorten:LogoutUrl"]);
                }
            }
            else
            {
                HttpContext.SignOutAsync();
                Response.Redirect("/");
            }
        }
    }
}