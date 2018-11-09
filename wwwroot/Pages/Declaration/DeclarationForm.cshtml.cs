using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id, Guid companyId)
        {
            try
            {
                DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/SendIn/" + Guid.Parse(id));

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/Thanks");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    try
        //    {
        //        ApiResult result;

        //        if (DeclarationItemForm.Id != Guid.Empty)
        //        {
        //            result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Update", DeclarationItemForm);
        //        }
        //        else
        //        {
        //            result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Add", DeclarationItemForm);
        //        }

        //        if (result.Succeeded)
        //        {
        //            return RedirectToPage("/Admin/DeclarationList");
        //        }

        //        return Page();
        //    }
        //    catch
        //    {
        //        return Page();
        //    }
        //}
    }
}