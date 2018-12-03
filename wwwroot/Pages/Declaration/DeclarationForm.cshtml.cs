using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
                var outcomeDataList = (await apiHttpClient.Get<List<OutcomeData>>("/api/Declaration/GetOutcomeDataList/" + id)).Data;

                TestGroupItemList = new List<TestGroupItem>();

                foreach (var declarationIndicatorGroup in DeclarationItemForm.IndicatorList.OrderBy(x=>x.TestGroupOrder))
                {
                    if (TestGroupItemList.All(x => x.Id != declarationIndicatorGroup.TestGroupItemId))
                    {
                        TestGroupItemList.Add(declarationIndicatorGroup.TestGroupItem);
                    }
                }

                if (outcomeDataList.Any())
                {
                    foreach (var item in DeclarationItemForm.IndicatorList)
                    {
                        foreach (var data in outcomeDataList)
                        {
                            if (data.IndicatorItemId == item.IndicatorItem.Id)
                            {
                                item.IndicatorItem.OutcomeData = data;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;

                var declarationTestItem = new DeclarationTestItem
                {
                    Id = DeclarationItemForm.Id,
                    DescriptionInText = GetAnswerFromFormString("answer_string_testitem_descriptionintext"),
                    Image1Id = GetAnswerFromFormImage("answer_image_testitem_image1"),
                    Image2Id = GetAnswerFromFormImage("answer_image_testitem_image2")
                };

                var outcomeDataList = new List<OutcomeData>();

                foreach (var declarationTestGroup in DeclarationItemForm.IndicatorList.OrderBy(x => x.TestGroupOrder).ThenBy(x => x.IndicatorInTestGroupOrder))
                {
                    var indicator = declarationTestGroup.IndicatorItem;

                    var outcomeData = new OutcomeData
                    {
                        Id = Guid.NewGuid(),
                        IndicatorItemId = indicator.Id,
                        RuleDataList = new List<RuleData>(),
                        DeclarationTestItemId = DeclarationItemForm.DeclarationTestItem.Id
                    };

                    foreach (var ruleItem in indicator.RuleList.OrderBy(x => x.Order))
                    {
                        outcomeData.RuleDataList.Add(new RuleData
                        {
                            Id = Guid.NewGuid(),
                            RuleItemId = ruleItem.Id,
                            AnswerDataList = ruleItem.AnswerList.OrderBy(x=>x.Order).Select(x => new AnswerData
                            {
                                Id = Guid.NewGuid(),
                                AnswerItemId = x.Id,
                                TypeOfAnswerId = x.TypeOfAnswerId,
                                String = GetAnswerFromFormString($"answer_string_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                Bool = GetAnswerFromFormBool($"answer_bool_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                Int = GetAnswerFromFormInt($"answer_int_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                ImageId = GetAnswerFromFormImage($"answer_image_{indicator.Id}_{ruleItem.Id}_{x.Id}")
                            }).ToList()
                        });
                    }

                    outcomeDataList.Add(outcomeData);
                }

                var result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Save/", new DeclarationSave {Id = DeclarationItemForm.Id, OutcomeDataList = outcomeDataList, DeclarationTestItem = declarationTestItem });

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationRead", new { id = DeclarationItemForm.DeclarationTestItem.Id });
                }

                return Page();
            }
            catch (Exception exception)
            {
                return Page();
            }
        }

        private Guid? GetAnswerFromFormImage(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !string.IsNullOrEmpty(formValue) ? Guid.Parse(formValue) : (Guid?) null;
        }

        private string GetAnswerFromFormString(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !string.IsNullOrEmpty(formValue) ? formValue : string.Empty;
        }

        private int? GetAnswerFromFormInt(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !string.IsNullOrEmpty(formValue) ? (int?) Convert.ToInt32(formValue) : null;
        }

        private bool? GetAnswerFromFormBool(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !string.IsNullOrEmpty(formValue) ? (bool?) Convert.ToBoolean(formValue) : null;
        }
    }
}