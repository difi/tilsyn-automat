using System;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
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