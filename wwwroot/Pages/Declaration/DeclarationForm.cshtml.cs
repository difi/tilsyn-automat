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
                                Bool = GetAnswerFromForm<Boolean>($"answer_bool_{indicator.Id}_{ruleItem.Id}_{x.Id}"),
                                Int = GetAnswerFromForm<Int32>($"answer_int_{indicator.Id}__{ruleItem.Id}_{x.Id}")
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
            catch
            {
                return Page();
            }
        }

        private String GetAnswerFromFormString(string idString)
        {
            var formValue = Request.Form[idString].ToString();

            if (!String.IsNullOrEmpty(formValue))
            {
                return formValue;
            }

            return String.Empty;
        }

        private T GetAnswerFromForm<T>(string idString) where T : new()
        {
            var formValue = Request.Form[idString].ToString();

            if (!String.IsNullOrEmpty(formValue))
            {
                return (T)Convert.ChangeType(formValue, typeof(T));
            }

            return new T();
        }
    }
}