using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationReadModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public bool AllDoneStep1 { get; set; }

        public DeclarationReadModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
                var outcomeDataList = (await apiHttpClient.Get<List<OutcomeData>>("/api/Declaration/GetOutcomeDataList/" + id)).Data;

                AllDoneStep1 = DeclarationItemForm.DeclarationTestItem.SupplierAndVersionId > 0 && !string.IsNullOrEmpty(DeclarationItemForm.DeclarationTestItem.DescriptionInText) && DeclarationItemForm.DeclarationTestItem.Image1Id != null && DeclarationItemForm.DeclarationTestItem.Image2Id != null;

                TestGroupItemList = new List<TestGroupItem>();

                foreach (var declarationIndicatorGroup in DeclarationItemForm.IndicatorList.OrderBy(x => x.TestGroupOrder))
                {
                    if (TestGroupItemList.All(x => x.Id != declarationIndicatorGroup.TestGroupItemId))
                    {
                        var item = declarationIndicatorGroup.TestGroupItem;
                        item.AllDone = true;

                        TestGroupItemList.Add(item);
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

                                if (!data.AllDone)
                                {
                                    foreach (var indicatorTestGroup in data.Indicator.TestGroupList)
                                    {
                                        var testGroup = TestGroupItemList.Single(x => x.Id == indicatorTestGroup.TestGroupItemId);
                                        testGroup.AllDone = false;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                apiHttpClient.LogError(exception, id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/SendIn/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationThanks", new {id = id});
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}