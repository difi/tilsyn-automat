using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    [Authorize(Roles = "Virksomhet")]
    public class DeclarationThanksModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<DeclarationThanksModel> localizer;
        private readonly IApiHttpClient apiHttpClient;

        public DeclarationItem DeclarationItemForm { get; set; }

        public DeclarationThanksModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<DeclarationThanksModel> localizer)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var resultUser = await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                if (!resultUser.Succeeded || resultUser.Data.CompanyList == null || !resultUser.Data.CompanyList.Any())
                {
                    Response.Redirect("/");
                }

                var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);

                if (result.Succeeded)
                {
                    ViewData.Add("Done", localizer["Self-control sent in"]);

                    DeclarationItemForm = result.Data;
                }
                else
                {
                    await errorHandler.View(this, null, result.Exception);
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
            }
        }
    }
}