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
using Difi.Sjalvdeklaration.Shared.Extensions;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public List<OutcomeData> OutcomeDataForm { get; set; }

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

                await apiHttpClient.Post<ApiResult>("/api/Declaration/SendIn/", DeclarationItemForm);

                //    }
                //}

                //var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/SendIn/" + Guid.Parse(id));

                //if (result.Succeeded)
                //{
                //    return RedirectToPage("/Declaration/Thanks");
                //}

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
                return (T) Convert.ChangeType(formValue, typeof(T));
            }

            return new T();
        }
    }
}