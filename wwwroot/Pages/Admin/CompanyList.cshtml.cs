using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Enum;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class CompanyListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public IList<CompanyItem> CompanyList { get; private set; }

        public CompanyItem LocalizationItem { get; set; }

        private List<ValueListTypeOfMachine> valueListTypeOfMachine;
        private List<ValueListTypeOfTest> valueListTypeOfTest;
        private List<ValueListPurposeOfTest> valueListPurposeOfTest;

        [BindProperty]
        [Required(ErrorMessage = "You need to select a Excelfile")]
        [Display(Name = "Excel file")]
        public IFormFile ExcelFile { get; set; }

        public int ImportTryCount { get; set; }

        public int ImportIOkCount { get; set; }

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
                ImportIOkCount = 0;
                ImportTryCount = 0;

                var package = new ExcelPackage(ExcelFile.OpenReadStream());

                var dataTable = package.ToDataTable();

                valueListTypeOfMachine = (await apiHttpClient.Get<List<ValueListTypeOfMachine>>("/api/ValueList/GetAllTypeOfMachine")).Data;
                valueListTypeOfTest = (await apiHttpClient.Get<List<ValueListTypeOfTest>>("/api/ValueList/GetAllTypeOfTest")).Data;
                valueListPurposeOfTest = (await apiHttpClient.Get<List<ValueListPurposeOfTest>>("/api/ValueList/GetAllPurposeOfTest")).Data;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ImportTryCount++;
                    var result = await apiHttpClient.Post<ApiResult>("/api/Company/ExcelImport", CreateExcelItemRow(dataRow));

                    if (result.Succeeded)
                    {
                        ImportIOkCount++;
                    }
                }

                await OnGetAsync();

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        private ExcelItemRow CreateExcelItemRow(DataRow dataRow)
        {
            var companyId = Guid.NewGuid();
            var declarationItemId = Guid.NewGuid();

            var excelRow = new ExcelItemRow
            {
                CompanyItem = new CompanyItem
                {
                    Id = companyId,
                    Name = dataRow["Virksomhet - Navn"].ToString(),
                    CorporateIdentityNumber = dataRow["Virksomhet - Organisasjonsnummer"].ToString(),
                    Code = dataRow["Virksomhet - Pinkode"].ToString(),

                    MailingAddressStreet = dataRow["Postadresse - Adresse gate"].ToString(),
                    MailingAddressZip = dataRow["Postadresse - Adresse postnr"].ToString(),
                    MailingAddressCity = dataRow["Postadresse - Adresse poststed"].ToString(),

                    BusinessAddressStreet = dataRow["Beliggenhetsadresse - Adresse gate"].ToString(),
                    BusinessAddressZip = dataRow["Beliggenhetsadresse - Adresse postnr"].ToString(),
                    BusinessAddressCity = dataRow["Beliggenhetsadresse - Adresse poststed"].ToString(),

                    LocationAddressStreet = dataRow["Forretningsadresse - Adresse gate"].ToString(),
                    LocationAddressZip = dataRow["Forretningsadresse - Adresse postnr"].ToString(),
                    LocationAddressCity = dataRow["Forretningsadresse - Adresse poststed"].ToString(),

                    IndustryGroupCode = dataRow["Næringsgruppe - Kode"].ToString(),
                    IndustryGroupDescription = dataRow["Næringsgruppe - Beskrivelse"].ToString(),
                    IndustryGroupAggregated = dataRow["Næringsgruppe - Aggregert"].ToString(),

                    InstitutionalSectorCode = dataRow["Institusjonell sektorkode - Kode"].ToString(),
                    InstitutionalSectorDescription = dataRow["Institusjonell sektorkode - Beskrivelse"].ToString(),

                    OwenerCorporateIdentityNumber = string.Empty
                },
                ContactPersonItem = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = dataRow["Kontaktperson - Navn"].ToString(),
                    Email = dataRow["Kontaktperson - Epostadresse"].ToString(),
                    PhoneCountryCode = dataRow["Kontaktperson - Telefonnummer Landskode"].ToString(),
                    Phone = dataRow["Kontaktperson - Telefonnummer"].ToString(),
                    CompanyItemId = companyId,
                }
            };

            if (string.IsNullOrEmpty(excelRow.CompanyItem.Code))
            {
                var random = new Random(DateTime.Now.Millisecond);

                excelRow.CompanyItem.Code = random.Next(1000, 9999).ToString();
            }

            if (!string.IsNullOrEmpty(dataRow["Automat - Navn"].ToString()))
            {
                excelRow.DeclarationItem = new DeclarationItem
                {
                    Id = declarationItemId,
                    CompanyItemId = companyId,
                    UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                    Name = dataRow["Automat - Navn"].ToString(),
                    CreatedDate = DateTime.Now,
                    DeadlineDate = DateTime.Now.Date.AddDays(14),
                    StatusId = (int) DeclarationStatus.Created,
                    DeclarationTestItem = new DeclarationTestItem
                    {
                        Id = declarationItemId,
                        TypeOfMachine = valueListTypeOfMachine.Single(x => x.Id == 1),
                        TypeOfTest = valueListTypeOfTest.Single(x => x.Id == 1),
                        PurposeOfTestId = valueListPurposeOfTest.Single(x => x.Id == 2).Id
                    }
                };
            }

            return excelRow;
        }
    }

    public class ExcelUploadForm
    {

    }
}