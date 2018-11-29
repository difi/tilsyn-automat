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
        private readonly IApiHttpClient apiHttpClient;

        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public DeclarationReadModel(IApiHttpClient apiHttpClient)
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

                foreach (var declarationIndicatorGroup in DeclarationItemForm.IndicatorList.OrderBy(x => x.TestGroupOrder))
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

        [HttpPost]
        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/SendIn/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationList");
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