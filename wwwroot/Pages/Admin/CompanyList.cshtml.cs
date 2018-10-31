using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Business;
using Microsoft.AspNetCore.Authorization;

namespace Difi.Sjalvdeklaration.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class CompanyListModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public IList<CompanyItem> CompanyList { get; private set; }

        public CompanyListModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            CompanyList = await apiHttpClient.Get<List<CompanyItem>>("/api/Company/GetAll");
        }

        public async Task<IActionResult> OnPostRemoveCompanyAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<bool>("/api/Company/Remove/" + id);

                if (result)
                {
                    return RedirectToPage("/Admin/CompanyList");
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