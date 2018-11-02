using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationListModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public Int32 ViewCount { get; set; }

        public Int32 TotalCount { get; set; }

        public DeclarationListModel(ApiHttpClient apiHttpClient)
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

                using (var excelRange = excelWorksheet.Cells["A1:H1"])
                {
                    excelRange.Style.Font.Bold = true;
                    excelRange.Style.Font.Size = excelRange.Style.Font.Size + 2;
                    excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    excelRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                using (var excelRange = excelWorksheet.Cells["A1:H100"])
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

            dataTable.Columns.Add(new DataColumn("Virksomhet - Namn"));
            dataTable.Columns.Add(new DataColumn("Virksomhet - Organisationsnummer"));
            dataTable.Columns.Add(new DataColumn("Automat - Namn"));
            dataTable.Columns.Add(new DataColumn("Frist for innsending"));
            dataTable.Columns.Add(new DataColumn("Dato sendt inn"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Namn"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - E-post"));
            dataTable.Columns.Add(new DataColumn("Kontaktperson - Telefon"));

            foreach (var declarationItem in declarationItems)
            {
                var dataRow = dataTable.NewRow();

                dataRow["Virksomhet - Namn"] = declarationItem.Company.Name;
                dataRow["Virksomhet - Organisationsnummer"] = declarationItem.Company.CorporateIdentityNumber;
                dataRow["Automat - Namn"] = declarationItem.Name;
                dataRow["Frist for innsending"] = declarationItem.DeadLineDate;
                dataRow["Dato sendt inn"] = declarationItem.SentInDate;
                dataRow["Kontaktperson - Namn"] = declarationItem.User.Name;
                dataRow["Kontaktperson - E-post"] = declarationItem.User.Email;
                dataRow["Kontaktperson - Telefon"] = declarationItem.User.Phone;

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}