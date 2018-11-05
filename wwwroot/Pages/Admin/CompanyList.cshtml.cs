using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("Narvesen", "123456789", "1111", "Automat for betaling på Oslo S"));
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("Norwegian", "987654321", "2222", "Billettautomat Gardemoen"));
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("NSB", "1122334451", "3333", "Billettautomat på Oslo S"));
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("Esso", "1122334452", "4444", "Betalingsautomat Trondheim"));
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("7 - eleven", "1122334453", "5555", "Automat Grensen"));
                await apiHttpClient.Post<bool>("/api/Company/ExcelImport", CreateExcelItemRow("Norske bank", "1122334454", "6666", "Billettautomat Kristiansand"));

                return RedirectToPage("/Admin/CompanyList");
            }
            catch
            {
                return Page();
            }
        }

        private ExcelItemRow CreateExcelItemRow(string companyName, string corporateIdentityNumber, string code, string declarationName)
        {
            var companyId = Guid.NewGuid();

            return new ExcelItemRow
            {
                CompanyItem = new CompanyItem
                {
                    Id = companyId,
                    Name = companyName,
                    CorporateIdentityNumber = corporateIdentityNumber,
                    Code = code,
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                },
                ContactPersonItem = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = companyId
                },
                DeclarationItem = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = companyId,
                    UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                    Name = declarationName,
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.NotStarted
                }
            };
        }
    }
}