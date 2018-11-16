using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Enum;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class CompanyListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public IList<CompanyItem> CompanyList { get; private set; }

        private List<ValueListTypeOfMachine> valueListTypeOfMachine;
        private List<ValueListTypeOfTest> valueListTypeOfTest;
        private List<ValueListTypeOfSupplierAndVersion> valueListTypeOfSupplierAndVersion;

        public CompanyListModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            CompanyList = (await apiHttpClient.Get<List<CompanyItem>>("/api/Company/GetAll")).Data;
        }

        public async Task<IActionResult> OnPostExcelImportAsync()
        {
            try
            {
                valueListTypeOfMachine = (await apiHttpClient.Get<List<ValueListTypeOfMachine>>("/api/ValueList/GetAllTypeOfMachine")).Data;
                valueListTypeOfTest = (await apiHttpClient.Get<List<ValueListTypeOfTest>>("/api/ValueList/GetAllTypeOfTest")).Data;
                valueListTypeOfSupplierAndVersion  = (await apiHttpClient.Get<List<ValueListTypeOfSupplierAndVersion>>("/api/ValueList/GetAllTypeOfSupplierAndVersion")).Data;

                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("Narvesen", "123456789", "1111", "Automat for betaling på Oslo S"));
                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("Norwegian", "987654321", "2222", "Billettautomat Gardemoen"));
                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("NSB", "1122334451", "3333", "Billettautomat på Oslo S"));
                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("Esso", "1122334452", "4444", "Betalingsautomat Trondheim"));
                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("7 - eleven", "1122334453", "5555", "Automat Grensen"));
                await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow("Norske bank", "1122334454", "6666", "Billettautomat Kristiansand"));

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
            var declarationItemId = Guid.NewGuid();

            return new ExcelItemRow
            {
                CompanyItem = new CompanyItem
                {
                    Id = companyId,
                    Name = companyName,
                    CorporateIdentityNumber = corporateIdentityNumber,
                    Code = code,
                    MailingAddressStreet = "Triangelbygget 12",
                    MailingAddressZip = "4200",
                    MailingAddressCity = "SAUDA"
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
                    Id = declarationItemId,
                    CompanyItemId = companyId,
                    UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                    Name = declarationName,
                    CreatedDate = DateTime.Now,
                    DeadlineDate = DateTime.Now.Date.AddMonths(6),
                    Status = DeclarationStatus.Created,
                    DeclarationTestItem = new DeclarationTestItem
                    {
                        Id = declarationItemId,
                        TypeOfMachine = valueListTypeOfMachine.Single(x => x.Id == 1),
                        TypeOfTest = valueListTypeOfTest.Single(x => x.Id == 1)
                    }
                }
            };
        }
    }
}