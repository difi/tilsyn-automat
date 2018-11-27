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

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

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

                var outcomeDataList = new List<OutcomeData>();

                foreach (var declarationTestGroup in DeclarationItemForm.IndicatorList)
                {
                    var indicator = declarationTestGroup.IndicatorItem;

                    var outcomeData = new OutcomeData
                    {
                        Id = Guid.NewGuid(),
                        IndicatorItemId = indicator.Id,
                        RuleDataList = new List<RuleData>(),
                        DeclarationTestItemId = DeclarationItemForm.DeclarationTestItem.Id
                    };

                    foreach (var ruleItem in indicator.RuleList)
                    {
                        outcomeData.RuleDataList.Add(new RuleData
                        {
                            Id = Guid.NewGuid(),
                            RuleItemId = ruleItem.Id,
                            AnswerDataList = ruleItem.AnswerList.Select(x => new AnswerData
                            {
                                Id = Guid.NewGuid(),
                                AnswerItemId = x.Id,
                                TypeOfAnswerId = x.TypeOfAnswerId,
                                String = GetAnswerFromFormString($"answer_string_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                Bool = GetAnswerFromFormBool($"answer_bool_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                Int = GetAnswerFromFormInt($"answer_int_{indicator.Id}_{ruleItem.Id}_{x.Id}")
                            }).ToList()
                        });
                    }

                    outcomeDataList.Add(outcomeData);
                }

                var result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Save/", new DeclarationSave {Id = DeclarationItemForm.Id, OutcomeDataList = outcomeDataList});

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

        private String GetAnswerFromFormString(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !String.IsNullOrEmpty(formValue) ? formValue : String.Empty;
        }

        private int? GetAnswerFromFormInt(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !String.IsNullOrEmpty(formValue) ? (int?) Convert.ToInt32(formValue) : null;
        }

        private bool? GetAnswerFromFormBool(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            return !String.IsNullOrEmpty(formValue) ? (bool?) Convert.ToBoolean(formValue) : null;
        }
    }
}