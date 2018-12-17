using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Declaration
{
    public class DeclarationTestHelper
    {
        public DeclarationTestItem CreateDeclarationTestItem(IDictionary<string, string> dataList, Guid id, List<DeclarationIndicatorGroup> indicatorList)
        {
            var declarationTestItem = new DeclarationTestItem
            {
                Id = id,
                SupplierAndVersionId = GetAnswerFromInt(dataList, "answer_int_supplierandversion"),
                SupplierAndVersionOther = GetAnswerFromString(dataList, "answer_string_testitem_supplierandversionother"),
                DescriptionInText = GetAnswerFromString(dataList, "answer_string_testitem_descriptionintext"),
                Image1Id = GetAnswerFromImage(dataList, "answer_image_testitem_image1"),
                Image2Id = GetAnswerFromImage(dataList, "answer_image_testitem_image2")
            };

            var outcomeDataList = new List<OutcomeData>();

            foreach (var declarationTestGroup in indicatorList.OrderBy(x => x.TestGroupOrder).ThenBy(x => x.IndicatorInTestGroupOrder))
            {
                var indicator = declarationTestGroup.IndicatorItem;

                var outcomeData = new OutcomeData
                {
                    Id = Guid.NewGuid(),
                    IndicatorItemId = indicator.Id,
                    RuleDataList = new List<RuleData>(),
                    DeclarationTestItemId = id
                };

                foreach (var ruleItem in indicator.RuleList.OrderBy(x => x.Order))
                {
                    outcomeData.RuleDataList.Add(new RuleData
                    {
                        Id = Guid.NewGuid(),
                        RuleItemId = ruleItem.Id,
                        AnswerDataList = ruleItem.AnswerList.OrderBy(x => x.Order).Select(x => new AnswerData
                        {
                            Id = Guid.NewGuid(),
                            AnswerItemId = x.Id,
                            TypeOfAnswerId = x.TypeOfAnswerId,
                            String = GetAnswerFromString(dataList, $"answer_string_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                            Bool = GetAnswerFromBool(dataList, $"answer_bool_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                            Int = GetAnswerFromInt(dataList, $"answer_int_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                            ImageId = GetAnswerFromImage(dataList, $"answer_image_{indicator.Id}_{ruleItem.Id}_{x.Id}")
                        }).ToList()
                    });
                }

                outcomeDataList.Add(outcomeData);
            }

            declarationTestItem.OutcomeDataList = outcomeDataList;

            return declarationTestItem;
        }

        private static Guid? GetAnswerFromImage(IDictionary<string, string> dataList, string idString)
        {
            if (!dataList.ContainsKey(idString))
            {
                return (Guid?) null;
            }

            var item = dataList.Single(x => x.Key == idString);

            return !string.IsNullOrEmpty(item.Value) ? Guid.Parse(item.Value) : (Guid?)null;
        }

        private static string GetAnswerFromString(IDictionary<string, string> dataList, string idString)
        {
            if (!dataList.ContainsKey(idString))
            {
                return string.Empty;
            }

            var item = dataList.Single(x => x.Key == idString);

            return !string.IsNullOrEmpty(item.Value) ? item.Value : string.Empty;
        }

        private static int? GetAnswerFromInt(IDictionary<string, string> dataList, string idString)
        {
            if (!dataList.ContainsKey(idString))
            {
                return null;
            }

            var item = dataList.Single(x => x.Key == idString);

            return !string.IsNullOrEmpty(item.Value) ? (int?)Convert.ToInt32(item.Value) : null;
        }

        private static bool? GetAnswerFromBool(IDictionary<string, string> dataList, string idString)
        {
            if (!dataList.ContainsKey(idString))
            {
                return null;
            }

            var item = dataList.Single(x => x.Key == idString);

            return !string.IsNullOrEmpty(item.Value) ? (bool?)Convert.ToBoolean(item.Value) : null;
        }
    }
}
