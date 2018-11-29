using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationItem LocalizationItem { get; set; }

        public Int32 ViewCount { get; set; }

        public Int32 TotalCount { get; set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                DeclarationList = (await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll")).Data;

                ViewCount = DeclarationList.Count;
                TotalCount = DeclarationList.Count;
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostExportDeclarationAsync(string id)
        {
            try
            {
                var result = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + Guid.Parse(id))).Data;

                var data = GenerateExcel(new List<DeclarationItem> { result });

                return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"export_{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}.xlsx");
            }
            catch
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostExportDeclarationListAsync()
        {
            try
            {
                var data = GenerateExcel((await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll")).Data);

                return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"export_{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}.xlsx");
            }
            catch
            {
                return Page();
            }
        }

        private byte[] GenerateExcel(IEnumerable<DeclarationItem> list)
        {
            var dataTable = GetDataTable(list);

            using (var pck = new ExcelPackage())
            {
                var excelWorksheet = pck.Workbook.Worksheets.Add("Data");
                excelWorksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                using (var excelRange = excelWorksheet.Cells["A1:AI1"])
                {
                    excelRange.Style.Font.Bold = true;
                    excelRange.Style.Font.Size = excelRange.Style.Font.Size + 2;
                    excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    excelRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                using (var excelRange = excelWorksheet.Cells["A1:AI100"])
                {
                    excelRange.AutoFitColumns();
                }

                return pck.GetAsByteArray();
            }
        }

        private static DataTable GetDataTable(IEnumerable<DeclarationItem> declarationItems)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Automat - Navn"));
            dataTable.Columns.Add(new DataColumn("Frist for innsending"));
            dataTable.Columns.Add(new DataColumn("Dato sendt inn"));
            dataTable.Columns.Add(new DataColumn("Status for egenkontroll"));
            dataTable.Columns.Add(new DataColumn("Status for tillsyn"));

            dataTable.Columns.Add(new DataColumn("TypeOfMachine"));
            dataTable.Columns.Add(new DataColumn("TypeOfTest"));

            dataTable.Columns.Add(new DataColumn("Virksomhet - Pinkode"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - ID (tilsynets datamodell)"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Organisationsnummer"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Navn"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Endret navn"));

            dataTable.Columns.Add(new DataColumn("Postadresse - Adresse gate"));
            dataTable.Columns.Add(new DataColumn("Postadresse - Adresse postnr"));
            dataTable.Columns.Add(new DataColumn("Postadresse - Adresse poststed"));

            dataTable.Columns.Add(new DataColumn("Beliggenhetsadresse - Adresse gate"));
            dataTable.Columns.Add(new DataColumn("Beliggenhetsadresse - Adresse postnr"));
            dataTable.Columns.Add(new DataColumn("Beliggenhetsadresse - Adresse poststed"));

            dataTable.Columns.Add(new DataColumn("Forretningsadresse - Adresse gate"));
            dataTable.Columns.Add(new DataColumn("Forretningsadresse - Adresse postnr"));
            dataTable.Columns.Add(new DataColumn("Forretningsadresse - Adresse poststed"));

            dataTable.Columns.Add(new DataColumn("Næringsgruppe - Kode"));
            dataTable.Columns.Add(new DataColumn("Næringsgruppe - Beskrivelse"));
            dataTable.Columns.Add(new DataColumn("Næringsgruppe - Aggregert"));

            dataTable.Columns.Add(new DataColumn("Institusjonell sektorkode - Kode"));
            dataTable.Columns.Add(new DataColumn("Institusjonell sektorkode - Beskrivelse"));

            dataTable.Columns.Add(new DataColumn("Kontaktperson - Navn"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Epostadresse"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Telefonnummer Landskode"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Telefonnummer"));

            dataTable.Columns.Add(new DataColumn("Saksbehandler - Navn"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Epostadresse"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Telefonnummer Landskode"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Telefonnummer"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Title"));

            foreach (var declarationItem in declarationItems)
            {
                var dataRow = dataTable.NewRow();

                dataRow["Automat - Navn"] = declarationItem.Name;
                dataRow["Frist for innsending"] = declarationItem.DeadlineDate;
                dataRow["Dato sendt inn"] = declarationItem.SentInDate;
                dataRow["Status for egenkontroll"] = declarationItem.Status.TextAdmin;
                dataRow["Status for tillsyn"] = declarationItem.Status.TextCompany;

                dataRow["TypeOfMachine"] = declarationItem.DeclarationTestItem.TypeOfMachine.Text;
                dataRow["TypeOfTest"] = declarationItem.DeclarationTestItem.TypeOfTest.Text;

                dataRow["Virksomhet - Pinkode"] = declarationItem.Company.Code;
                dataRow["Virksomhet - ID (tilsynets datamodell)"] = declarationItem.Company.CorporateIdentityNumber;
                dataRow["Virksomhet - Organisationsnummer"] = declarationItem.Company.CorporateIdentityNumber;
                dataRow["Virksomhet - Navn"] = declarationItem.Company.Name;
                dataRow["Virksomhet - Endret navn"] = declarationItem.Company.CustomName;

                dataRow["Postadresse - Adresse gate"] = declarationItem.Company.MailingAddressStreet;
                dataRow["Postadresse - Adresse postnr"] = declarationItem.Company.MailingAddressZip;
                dataRow["Postadresse - Adresse poststed"] = declarationItem.Company.MailingAddressCity;

                dataRow["Beliggenhetsadresse - Adresse gate"] = declarationItem.Company.BusinessAddressStreet;
                dataRow["Beliggenhetsadresse - Adresse postnr"] = declarationItem.Company.BusinessAddressZip;
                dataRow["Beliggenhetsadresse - Adresse poststed"] = declarationItem.Company.BusinessAddressCity;

                dataRow["Forretningsadresse - Adresse gate"] = declarationItem.Company.LocationAddressStreet;
                dataRow["Forretningsadresse - Adresse postnr"] = declarationItem.Company.LocationAddressZip;
                dataRow["Forretningsadresse - Adresse poststed"] = declarationItem.Company.LocationAddressCity;

                dataRow["Næringsgruppe - Kode"] = declarationItem.Company.IndustryGroupCode;
                dataRow["Næringsgruppe - Beskrivelse"] = declarationItem.Company.IndustryGroupDescription;
                dataRow["Næringsgruppe - Aggregert"] = declarationItem.Company.IndustryGroupAggregated;

                dataRow["Institusjonell sektorkode - Kode"] = declarationItem.Company.InstitutionalSectorCode;
                dataRow["Institusjonell sektorkode - Beskrivelse"] = declarationItem.Company.InstitutionalSectorDescription;

                if (declarationItem.Company.ContactPersonList != null && declarationItem.Company.ContactPersonList.Any())
                {
                    dataRow["Kontaktperson - Navn"] = declarationItem.Company.ContactPersonList[0]?.Name;
                    dataRow["Kontaktperson - Epostadresse"] = declarationItem.Company.ContactPersonList[0]?.Email;
                    dataRow["Kontaktperson - Telefonnummer Landskode"] = declarationItem.Company.ContactPersonList[0]?.PhoneCountryCode;
                    dataRow["Kontaktperson - Telefonnummer"] = declarationItem.Company.ContactPersonList[0]?.Phone;
                }

                if (declarationItem.User != null)
                {
                    dataRow["Saksbehandler - Navn"] = declarationItem.User.Name;
                    dataRow["Saksbehandler - Epostadresse"] = declarationItem.User.Email;
                    dataRow["Saksbehandler - Telefonnummer Landskode"] = declarationItem.User.PhoneCountryCode;
                    dataRow["Saksbehandler - Telefonnummer"] = declarationItem.User.Phone;
                    dataRow["Saksbehandler - Title"] = declarationItem.User.Title;
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}