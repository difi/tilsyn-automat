using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public string StorageAccountName { get; set; }

        public string StorageContainer { get; set; }

        [BindProperty]
        [Display(Name = "Välj")]
        public List<SelectListItem> SelectSupplierAndVersionList { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IConfiguration configuration)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;

            StorageAccountName = configuration["Azure:StorageAccountName"];
            StorageContainer = configuration["Azure:StorageContainer"];
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                if (await CreateLists())
                {
                    var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);

                    if (result.Succeeded)
                    {
                        DeclarationItemForm = result.Data;

                        await GetOutcomeDataList(id);
                    }
                    else
                    {
                        await errorHandler.View(this, null, result.Exception);
                    }
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                var resultDeclaration = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);

                if (resultDeclaration.Succeeded)
                {
                    DeclarationItemForm = resultDeclaration.Data;
                }
                else
                {
                    await errorHandler.View(this, OnGetAsync(Guid.Parse(id)), resultDeclaration.Exception);
                }

                var declarationTestItem = new DeclarationTestItem
                {
                    Id = DeclarationItemForm.Id,
                    SupplierAndVersionId = GetAnswerFromFormInt("answer_int_supplierandversion"),
                    SupplierAndVersionOther = GetAnswerFromFormString("answer_string_testitem_supplierandversionother"),
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

                return await errorHandler.View(this, OnGetAsync(Guid.Parse(id)), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(Guid.Parse(id)), exception, DeclarationItemForm);
            }
        }

        private async Task<bool> GetOutcomeDataList(Guid id)
        {
            var result = await apiHttpClient.Get<List<OutcomeData>>("/api/Declaration/GetOutcomeDataList/" + id);

            if (!result.Succeeded)
            {
                await errorHandler.View(this, null, result.Exception);
                return false;
            }

            TestGroupItemList = new List<TestGroupItem>();

            foreach (var declarationIndicatorGroup in DeclarationItemForm.IndicatorList.OrderBy(x => x.TestGroupOrder))
            {
                if (TestGroupItemList.All(x => x.Id != declarationIndicatorGroup.TestGroupItemId))
                {
                    TestGroupItemList.Add(declarationIndicatorGroup.TestGroupItem);
                }
            }

            if (!result.Data.Any())
            {
                return true;
            }

            foreach (var item in DeclarationItemForm.IndicatorList)
            {
                foreach (var data in result.Data)
                {
                    if (data.IndicatorItemId == item.IndicatorItem.Id)
                    {
                        item.IndicatorItem.OutcomeData = data;
                    }
                }
            }

            return true;
        }

        private async Task<bool> CreateLists()
        {
            var typeOfStatuses = await apiHttpClient.Get<List<ValueListTypeOfSupplierAndVersion>>("/api/ValueList/GetAllTypeOfSupplierAndVersion");

            if (!typeOfStatuses.Succeeded)
            {
                await errorHandler.View(this, null, typeOfStatuses.Exception);

                return false;
            }

            SelectSupplierAndVersionList = typeOfStatuses.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Text}",
                Selected = false
            }).ToList();

            return true;
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