using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationFormModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public DeclarationFormModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id, Guid companyId)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    DeclarationItemForm = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);
                }
                else
                {
                    DeclarationItemForm = new DeclarationItem
                    {
                        CompanyItemId = companyId,
                        DeadlineDate = DateTime.Now.Date.AddMonths(6)
                        
                    };
                }
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool result;

                if (DeclarationItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<bool>("/api/Declaration/Update", DeclarationItemForm);
                }
                else
                {
                    DeclarationItemForm.UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                    result = await apiHttpClient.Post<bool>("/api/Declaration/Add", DeclarationItemForm);
                }

                if (result)
                {
                    return RedirectToPage("/Admin/DeclarationList");
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