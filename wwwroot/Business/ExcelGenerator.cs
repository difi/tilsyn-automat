using Difi.Sjalvdeklaration.Shared.Attributes;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public class ExcelGenerator: IExcelGenerator
    {
        private readonly IApiHttpClient apiHttpClient;
        private readonly IStringLocalizer<DeclarationItem> localizerDeclarationItem;
        private readonly IStringLocalizer<DeclarationTestItem> localizerDeclarationTestItem;
        private readonly IStringLocalizer<CompanyItem> localizerCompanyItem;
        private readonly IStringLocalizer<UserItem> localizerUserItem;
        private readonly IStringLocalizer<ContactPersonItem> localizerContactPersonItem;

        public ExcelGenerator(IApiHttpClient apiHttpClient, IStringLocalizer<DeclarationItem> localizerDeclarationItem, IStringLocalizer<DeclarationTestItem> localizerDeclarationTestItem, IStringLocalizer<CompanyItem> localizerCompanyItem, IStringLocalizer<UserItem> localizerUserItem, IStringLocalizer<ContactPersonItem> localizerContactPersonItem)
        {
            this.apiHttpClient = apiHttpClient;
            this.localizerDeclarationItem = localizerDeclarationItem;
            this.localizerDeclarationTestItem = localizerDeclarationTestItem;
            this.localizerCompanyItem = localizerCompanyItem;
            this.localizerUserItem = localizerUserItem;
            this.localizerContactPersonItem = localizerContactPersonItem;
        }

        public byte[] GenerateExcel(IEnumerable<DeclarationItem> declarationList)
        {
            var dataTable = GetDataTable(declarationList.ToList());

            using (var pck = new ExcelPackage())
            {
                var excelWorksheet = pck.Workbook.Worksheets.Add("Data");
                excelWorksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                using (var excelRange = excelWorksheet.Cells["A1:BS1"])
                {
                    excelRange.Style.Font.Bold = true;
                    excelRange.Style.Font.Size = excelRange.Style.Font.Size + 2;
                    excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    excelRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                using (var excelRange = excelWorksheet.Cells["A1:BS100"])
                {
                    excelRange.AutoFitColumns();
                }

                return pck.GetAsByteArray();
            }
        }

        private DataTable GetDataTable(IReadOnlyCollection<DeclarationItem> declarationItems)
        {
            var dataTable = new DataTable();
            var indicatorList = declarationItems.First().IndicatorList.OrderBy(x => x.TestGroupOrder).ThenBy(x => x.IndicatorInTestGroupOrder).ToList();

            AddHeaders<DeclarationItem>(dataTable, "Egenkontroll", localizerDeclarationItem, out var count1);
            AddHeaders<DeclarationTestItem>(dataTable, "Egenkontroll", localizerDeclarationTestItem, out var count2);
            AddHeaders<CompanyItem>(dataTable, "Virksomhet", localizerCompanyItem, out var count3);
            AddHeaders<ContactPersonItem>(dataTable, "Kontaktperson", localizerContactPersonItem, out var count4);
            AddHeaders<UserItem>(dataTable, "Saksbehandler", localizerUserItem, out var count5);

            foreach (var indicatorGroup in indicatorList)
            {
                AddOutcomeHeader(dataTable, indicatorGroup.IndicatorItem);
            }

            var propertyListDeclarationItem = typeof(DeclarationItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            var propertyListDeclarationTestItem = typeof(DeclarationTestItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            var propertyListCompanyItem = typeof(CompanyItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            var propertyListContactPersonItem = typeof(ContactPersonItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();
            var propertyListUserItem = typeof(UserItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CustomAttributes.Count(y => y.AttributeType == typeof(ExcelExportAttribute)) == 1).ToArray();

            foreach (var item in declarationItems)
            {
                var values = new object[count1 + count2 + count3 + count4 + count5];

                GetValues(count1, 0, propertyListDeclarationItem, item, values);
                GetValues(count2, count1, propertyListDeclarationTestItem, item.DeclarationTestItem, values);
                GetValues(count3, count1 + count2, propertyListCompanyItem, item.Company, values);
                GetValues(count4, count1 + count2 + count3, propertyListContactPersonItem, item.Company.ContactPersonList.First(), values);
                GetValues(count5, count1 + count2 + count3 + count4, propertyListUserItem, item.User, values);

                var result = apiHttpClient.Get<List<OutcomeData>>("/api/Declaration/GetOutcomeDataList/" + item.Id).Result;

                dataTable.Rows.Add(values);

                var row = dataTable.Rows[dataTable.Rows.Count-1];

                if (result.Succeeded && result.Data != null && result.Data.Any())
                {
                    foreach (var indicatorGroup in indicatorList)
                    {
                        var data = result.Data.SingleOrDefault(x => x.IndicatorItemId == indicatorGroup.IndicatorItemId);

                        if (data != null)
                        {
                            row[indicatorGroup.IndicatorItem.Name + " - Klar"] = data.AllDone;
                            row[indicatorGroup.IndicatorItem.Name + " - Result"] = data.Result.Text;
                            row[indicatorGroup.IndicatorItem.Name + " - Result text"] = data.ResultText;
                            row[indicatorGroup.IndicatorItem.Name + " - Formulering på utfall"] = data.IndicatorOutcomeItem?.Language.OutcomeText;
                            row[indicatorGroup.IndicatorItem.Name + " - Krav"] = data.RuleDataList.First().Rule.Requirement.Language.Description;
                        }
                    }
                }
            }

            return dataTable;
        }

        private static void AddOutcomeHeader(DataTable dataTable, IndicatorItem indicatorItem)
        {
            dataTable.Columns.Add(indicatorItem.Name + " - Klar");
            dataTable.Columns.Add(indicatorItem.Name + " - Result");
            dataTable.Columns.Add(indicatorItem.Name + " - Result text");
            dataTable.Columns.Add(indicatorItem.Name + " - Krav");
            dataTable.Columns.Add(indicatorItem.Name + " - Formulering på utfall");
        }

        private static void GetValues(int currentCount, int totalCount, IReadOnlyList<PropertyInfo> propertyList, object item, IList<object> values)
        {
            for (var col = 0; col < currentCount; col++)
            {
                var value = propertyList[col].GetValue(item, null);

                if (value != null)
                {
                    if (value.GetType().BaseType == typeof(ValueList))
                    {
                        var test = (ValueList)value;
                        values[col + totalCount] = test.Text;
                    }
                    else if (value.GetType() == typeof(ImageItem))
                    {
                        var test = (ImageItem)value;
                        values[col + totalCount] = test.Container + "/" + test.Name;
                    }
                    else
                    {
                        values[col + totalCount] = value;
                    }
                }
            }
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

                var extraHeader = string.IsNullOrEmpty(excelExportAttribute.ExtraHeader) ? string.Empty : excelExportAttribute.ExtraHeader + " - ";
                var displayAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().SingleOrDefault();

                dataTable.Columns.Add(groupName + " - " + extraHeader + (displayAttribute != null ? stringLocalizer[displayAttribute.Name] : propertyInfo.Name));

                count++;
            }
        }
    }
}