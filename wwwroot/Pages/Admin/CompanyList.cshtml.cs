using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
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

        public async Task<IActionResult> OnPostExcelImportAsync()
        {
            try
            {
                var result = await apiHttpClient.Post<bool>("/api/Company/ExcelImport", null);

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