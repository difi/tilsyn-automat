using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Attributes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class DeclarationListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<DeclarationListModel> localizer;
        private readonly IStringLocalizer<DeclarationItem> localizerDeclarationItem;
        private readonly IStringLocalizer<DeclarationTestItem> localizerDeclarationTestItem;
        private readonly IStringLocalizer<CompanyItem> localizerCompanyItem;
        private readonly IStringLocalizer<UserItem> localizerUserItem;
        private readonly IStringLocalizer<ContactPersonItem> localizerContactPersonItem;
        private readonly IApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationItem LocalizationItem { get; set; }

        [BindProperty]
        public FilterModel FilterModel { get; set; }

        public List<SelectListItem> SelectStatusList { get; set; }

        public int ViewCount { get; set; }

        [BindProperty]
        public int TotalCount { get; set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<DeclarationListModel> localizer, IStringLocalizer<DeclarationItem> localizerDeclarationItem, IStringLocalizer<DeclarationTestItem> localizerDeclarationTestItem, IStringLocalizer<CompanyItem> localizerCompanyItem, IStringLocalizer<UserItem> localizerUserItem, IStringLocalizer<ContactPersonItem> localizerContactPersonItem)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
            this.localizerDeclarationItem = localizerDeclarationItem;
            this.localizerDeclarationTestItem = localizerDeclarationTestItem;
            this.localizerCompanyItem = localizerCompanyItem;
            this.localizerUserItem = localizerUserItem;
            this.localizerContactPersonItem = localizerContactPersonItem;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                if (await CreateLists())
                {
                    var result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");

                    if (result.Succeeded)
                    {
                        DeclarationList = result.Data;

                        ViewCount = DeclarationList.Count;
                        TotalCount = DeclarationList.Count;

                        FilterModel = new FilterModel
                        {
                            FromDate = DateTime.Now.Date,
                            ToDate = DateTime.Now.Date.AddMonths(1)
                        };
                    }
                    else
                    {
                        await errorHandler.View(this, null, result.Exception);
                    }
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostFilterAsync()
        {
            try
            {
                if (await CreateLists())
                {
                    var result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetByFilter/" + FilterModel.FromDate.Ticks + "/" + FilterModel.ToDate.Ticks + "/" + FilterModel.Status1 + "/" + FilterModel.Status2);

                    if (result.Succeeded)
                    {
                        DeclarationList = result.Data;
                        ViewCount = DeclarationList.Count;

                        return Page();
                    }

                    return await errorHandler.View(this, OnGetAsync(), result.Exception);
                }

                return null;
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostViewAllAsync()
        {
            return await errorHandler.View(this, OnGetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> OnPostExportDeclarationAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + Guid.Parse(id));

                if (result.Succeeded)
                {
                    var data = GenerateExcel(new List<DeclarationItem> { result.Data });

                    return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{result.Data.Name} ({DateTime.Now.GetAsFileName()}).xlsx");
                }

                return await errorHandler.View(this, OnGetAsync(), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception, id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostExportDeclarationListAsync()
        {
            try
            {
                var result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");

                if (result.Succeeded)
                {
                    var data = GenerateExcel(result.Data);

                    return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Alla ({DateTime.Now.GetAsFileName()}).xlsx");
                }

                return await errorHandler.View(this, OnGetAsync(), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception);
            }
        }

        private async Task<bool> CreateLists()
        {
            var typeOfStatuses = await apiHttpClient.Get<List<ValueListTypeOfStatus>>("/api/ValueList/GetAllTypeOfStatus");

            if (!typeOfStatuses.Succeeded)
            {
                await errorHandler.View(this, null, typeOfStatuses.Exception);

                return false;
            }

            SelectStatusList = typeOfStatuses.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.TextAdmin} - {x.TextCompany} ({x.Text})",
                Selected = false
            }).ToList();

            SelectStatusList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = localizer["All"]
            });

            return true;
        }

        private byte[] GenerateExcel(IEnumerable<DeclarationItem> list)
        {
            var dataTable = GetDataTable(list);

            //var dataTable = BuildDataTable<DeclarationItem>(list.ToList());

            using (var pck = new ExcelPackage())
            {
                var excelWorksheet = pck.Workbook.Worksheets.Add("Data");
                excelWorksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                using (var excelRange = excelWorksheet.Cells["A1:AX1"])
                {
                    excelRange.Style.Font.Bold = true;
                    excelRange.Style.Font.Size = excelRange.Style.Font.Size + 2;
                    excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    excelRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                using (var excelRange = excelWorksheet.Cells["A1:AX"])
                {
                    excelRange.AutoFitColumns();
                }

                return pck.GetAsByteArray();
            }
        }

        public DataTable BuildDataTable<T>(IList<T> data)
        {
            //Get properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            //.Where(p => !p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal).ToArray(); //Hides virtual properties

            //Get column headers
            var headers = new string[props.Length];
            var colCount = 0;

            foreach (var prop in props)
            {
                var isDisplayNameAttributeDefined = Attribute.IsDefined(prop, typeof(DisplayNameAttribute));

                if (isDisplayNameAttributeDefined)
                {
                    var dna = (DisplayNameAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));

                    if (dna != null)
                    {
                        headers[colCount] = dna.DisplayName;
                    }
                }
                else
                {
                    headers[colCount] = prop.Name;
                }

                colCount++;
            }

            var dataTable = new DataTable(typeof(T).Name);

            foreach (var header in headers)
            {
                dataTable.Columns.Add(header);
            }

            foreach (var item in data)
            {
                var values = new object[props.Length];
                for (var col = 0; col < props.Length; col++)
                {
                    values[col] = props[col].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }


        private DataTable GetDataTable(IEnumerable<DeclarationItem> declarationItems)
        {
            var dataTable = new DataTable();

            AddHeaders<DeclarationItem>(dataTable, "Egenkontroll", localizerDeclarationItem, out var count1);
            AddHeaders<DeclarationTestItem>(dataTable, "Egenkontroll", localizerDeclarationTestItem, out var count2);
            AddHeaders<CompanyItem>(dataTable, "Virksomhet", localizerCompanyItem, out var count3);
            AddHeaders<ContactPersonItem>(dataTable, "Kontaktperson", localizerContactPersonItem, out var count4);
            AddHeaders<UserItem>(dataTable, "Saksbehandler", localizerUserItem, out var count5);

            var props1 = typeof(DeclarationItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            

            foreach (var item in declarationItems)
            {
                var values = new object[count1 + count2 + count3 + count4 + count5];

                for (var col = 0; col < count1; col++)
                {
                    values[col] = props1[col].GetValue(item, null);
                }

                var props2 = item.DeclarationTestItem.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();

                for (var col = 0; col < count2; col++)
                {
                    values[count2] = props2[col].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;

            //foreach (var declarationItem in declarationItems)
            //{
            //    var dataRow = dataTable.NewRow();

            //    dataRow["Automat - Navn"] = declarationItem.Name;
            //    dataRow["Frist for innsending"] = declarationItem.DeadlineDate;
            //    dataRow["Dato sendt inn"] = declarationItem.SentInDate;
            //    dataRow["Status for egenkontroll"] = declarationItem.Status.TextAdmin;
            //    dataRow["Status for tillsyn"] = declarationItem.Status.TextCompany;

            //    dataRow["TypeOfMachine"] = declarationItem.DeclarationTestItem.TypeOfMachine.Text;
            //    dataRow["TypeOfTest"] = declarationItem.DeclarationTestItem.TypeOfTest.Text;

            //    dataRow["Virksomhet - Pinkode"] = declarationItem.Company.Code;
            //    dataRow["Virksomhet - ID (tilsynets datamodell)"] = declarationItem.Company.CorporateIdentityNumber;
            //    dataRow["Virksomhet - Organisasjonsnummer"] = declarationItem.Company.CorporateIdentityNumber;
            //    dataRow["Virksomhet - Navn"] = declarationItem.Company.Name;
            //    dataRow["Virksomhet - Endret navn"] = declarationItem.Company.CustomName;

            //    dataRow["Postadresse - Adresse gate"] = declarationItem.Company.MailingAddressStreet;
            //    dataRow["Postadresse - Adresse postnr"] = declarationItem.Company.MailingAddressZip;
            //    dataRow["Postadresse - Adresse poststed"] = declarationItem.Company.MailingAddressCity;

            //    dataRow["Beliggenhetsadresse - Adresse gate"] = declarationItem.Company.BusinessAddressStreet;
            //    dataRow["Beliggenhetsadresse - Adresse postnr"] = declarationItem.Company.BusinessAddressZip;
            //    dataRow["Beliggenhetsadresse - Adresse poststed"] = declarationItem.Company.BusinessAddressCity;

            //    dataRow["Forretningsadresse - Adresse gate"] = declarationItem.Company.LocationAddressStreet;
            //    dataRow["Forretningsadresse - Adresse postnr"] = declarationItem.Company.LocationAddressZip;
            //    dataRow["Forretningsadresse - Adresse poststed"] = declarationItem.Company.LocationAddressCity;

            //    dataRow["Næringsgruppe - Kode"] = declarationItem.Company.IndustryGroupCode;
            //    dataRow["Næringsgruppe - Beskrivelse"] = declarationItem.Company.IndustryGroupDescription;
            //    dataRow["Næringsgruppe - Aggregert"] = declarationItem.Company.IndustryGroupAggregated;

            //    dataRow["Institusjonell sektorkode - Kode"] = declarationItem.Company.InstitutionalSectorCode;
            //    dataRow["Institusjonell sektorkode - Beskrivelse"] = declarationItem.Company.InstitutionalSectorDescription;

            //    if (declarationItem.Company.ContactPersonList != null && declarationItem.Company.ContactPersonList.Any())
            //    {
            //        dataRow["Kontaktperson - Navn"] = declarationItem.Company.ContactPersonList[0]?.Name;
            //        dataRow["Kontaktperson - Epostadresse"] = declarationItem.Company.ContactPersonList[0]?.Email;
            //        dataRow["Kontaktperson - Telefonnummer Landskode"] = declarationItem.Company.ContactPersonList[0]?.PhoneCountryCode;
            //        dataRow["Kontaktperson - Telefonnummer"] = declarationItem.Company.ContactPersonList[0]?.Phone;
            //    }

            //    if (declarationItem.User != null)
            //    {
            //        dataRow["Saksbehandler - Navn"] = declarationItem.User.Name;
            //        dataRow["Saksbehandler - Epostadresse"] = declarationItem.User.Email;
            //        dataRow["Saksbehandler - Telefonnummer Landskode"] = declarationItem.User.PhoneCountryCode;
            //        dataRow["Saksbehandler - Telefonnummer"] = declarationItem.User.Phone;
            //        dataRow["Saksbehandler - Title"] = declarationItem.User.Title;
            //    }

            //    dataTable.Rows.Add(dataRow);
            //}

            //return dataTable;
        }

        private static void AddHeaders<T>(DataTable dataTable, string groupName, IStringLocalizer stringLocalizer, out int count)
        {
            count = 0;

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var excelExportAttribute = propertyInfo.GetCustomAttributes(typeof(ExcelExportAttribute), true).Cast<ExcelExportAttribute>().SingleOrDefault();

                if (excelExportAttribute == null)
                {
                    continue;
                }

                var extraHeader = string.IsNullOrEmpty(excelExportAttribute.ExtraHeader) ? string.Empty : " - " + excelExportAttribute.ExtraHeader + " - ";
                var displayAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().SingleOrDefault();

                dataTable.Columns.Add(groupName + " - " + extraHeader + (displayAttribute != null ? stringLocalizer[displayAttribute.Name] : propertyInfo.Name));

                count++;
            }
        }
    }
}