using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task OnGetAsync(Guid id, Guid companyId)
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

                foreach (var declarationTestGroup in DeclarationItemForm.TestGroupList)
                {
                    foreach (var requirementItem in declarationTestGroup.TestGroupItem.RequirementList)
                    {
                        requirementItem.OutcomeData = new OutcomeData
                        {
                            Id = Guid.NewGuid(),
                            RequirementItemId = requirementItem.Id,
                            RuleDataList = new List<RuleData>(),
                            DeclarationTestItemId = DeclarationItemForm.DeclarationTestItem.Id
                        };

                        foreach (var ruleItem in requirementItem.RuleList)
                        {
                            requirementItem.OutcomeData.RuleDataList.Add(new RuleData
                            {
                                Id = Guid.NewGuid(),
                                RuleItemId = ruleItem.Id,
                                AnswerDataList = ruleItem.AnswerList.Select(x => new AnswerData
                                {
                                    Id = Guid.NewGuid(),
                                    AnswerItemId = x.Id,
                                    TypeOfAnswerId = x.TypeOfAnswerId,
                                    Bool = GetAnswerFromForm<Boolean>($"answer_bool_{declarationTestGroup.TestGroupItemId}_{requirementItem.Id}_{ruleItem.Id}_{x.Id}")
                                }).ToList()
                            });
                        }
                    }
                }

                var result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Save/", DeclarationItemForm);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationRead/", new { id = DeclarationItemForm.DeclarationTestItem.Id });
                }

                return Page();
            }
            catch
            {
                return Page();
            }
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