using System;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationNoMachineModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        public DeclarationItem DeclarationItemForm { get; set; }

        public DeclarationNoMachineModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);

                if (result.Succeeded)
                {
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

        [HttpPost]
        public async Task<IActionResult> OnPostUpdateHaveMachineAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/HaveMachine/" + id + "/" + false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationList");
                }

                return await errorHandler.View(this, OnGetAsync(Guid.Parse(id)), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(Guid.Parse(id)), exception, id);
            }
        }
    }
}