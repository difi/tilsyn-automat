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

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

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
                DeclarationList = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");

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
                var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + Guid.Parse(id));

                await GenerateExcel(new List<DeclarationItem> { result });

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostExportDeclarationListAsync(string id)
        {
            try
            {
                await GenerateExcel(await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll"));

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        private async Task GenerateExcel(IEnumerable<DeclarationItem> list)
        {
            var dataTable = GetDataTable(list);

            using (var pck = new ExcelPackage())
            {
                var excelWorksheet = pck.Workbook.Worksheets.Add("Data");
                excelWorksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                using (var excelRange = excelWorksheet.Cells["A1:R1"])
                {
                    excelRange.Style.Font.Bold = true;
                    excelRange.Style.Font.Size = excelRange.Style.Font.Size + 2;
                    excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    excelRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                using (var excelRange = excelWorksheet.Cells["A1:R100"])
                {
                    excelRange.AutoFitColumns();
                }

                HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Response.Headers.Add("content-disposition", "attachment;  filename=export_" + DateTime.Now.ToShortDateString() + ".xlsx");

                await HttpContext.Response.Body.WriteAsync(pck.GetAsByteArray());
            }
        }

        private static DataTable GetDataTable(IEnumerable<DeclarationItem> declarationItems)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Automat - Namn"));
            dataTable.Columns.Add(new DataColumn("Frist for innsending"));
            dataTable.Columns.Add(new DataColumn("Dato sendt inn"));
            dataTable.Columns.Add(new DataColumn("Status"));

            dataTable.Columns.Add(new DataColumn("Virksomhet - Unikt passord"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Organisationsnummer"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Navn"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Endret navn"));

            dataTable.Columns.Add(new DataColumn("Virksomhet - Adresse gate"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Adresse postnr"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Adresse poststed"));

            dataTable.Columns.Add(new DataColumn("Kontaktperson - Namn"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - E-post"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Telefon"));

            dataTable.Columns.Add(new DataColumn("Saksbehandler - Namn"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - E-post"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Telefon"));
            dataTable.Columns.Add(new DataColumn("Saksbehandler - Title"));

            foreach (var declarationItem in declarationItems)
            {
                var dataRow = dataTable.NewRow();

                dataRow["Automat - Namn"] = declarationItem.Name;
                dataRow["Frist for innsending"] = declarationItem.DeadlineDate;
                dataRow["Dato sendt inn"] = declarationItem.SentInDate;
                dataRow["Status"] = declarationItem.Status;

                dataRow["Virksomhet - Unikt passord"] = declarationItem.Company.Code;
                dataRow["Virksomhet - Organisationsnummer"] = declarationItem.Company.CorporateIdentityNumber;
                dataRow["Virksomhet - Navn"] = declarationItem.Company.Name;
                dataRow["Virksomhet - Endret navn"] = declarationItem.Company.CustomName;

                dataRow["Virksomhet - Adresse gate"] = declarationItem.Company.AddressStreet;
                dataRow["Virksomhet - Adresse postnr"] = declarationItem.Company.AddressZip;
                dataRow["Virksomhet - Adresse poststed"] = declarationItem.Company.AddressCity;

                if (declarationItem.Company.ContactPersonList != null && declarationItem.Company.ContactPersonList.Any())
                {
                    dataRow["Kontaktperson - Namn"] = declarationItem.Company.ContactPersonList[0]?.Name;
                    dataRow["Kontaktperson - E-post"] = declarationItem.Company.ContactPersonList[0]?.Email;
                    dataRow["Kontaktperson - Telefon"] = declarationItem.Company.ContactPersonList[0]?.Phone;
                }

                if (declarationItem.User != null)
                {
                    dataRow["Saksbehandler - Namn"] = declarationItem.User.Name;
                    dataRow["Saksbehandler - E-post"] = declarationItem.User.Email;
                    dataRow["Saksbehandler - Telefon"] = declarationItem.User.Phone;
                    dataRow["Saksbehandler - Title"] = declarationItem.User.Title;
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}