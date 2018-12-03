using System;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationStartModel : PageModel
    {
        public DeclarationItem DeclarationItemForm { get; set; }

        private readonly IApiHttpClient apiHttpClient;

        public DeclarationStartModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdateHaveMachineAsync(string id, bool haveMachine)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/HaveMachine/" + id + "/" + haveMachine);

                if (result.Succeeded)
                {
                    return haveMachine ? RedirectToPage("/Declaration/DeclarationForm", new {id = id}) : RedirectToPage("/Declaration/DeclarationList");
                } 

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}