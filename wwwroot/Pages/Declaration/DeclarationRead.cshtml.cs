using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationReadModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public DeclarationItem DeclarationItemForm { get; set; }

        public DeclarationReadModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var OutcomeDataList = (await apiHttpClient.Get<List<OutcomeData>>("/api/Declaration/GetOutcomeDataList/" + id)).Data;

                DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;

                foreach (var item in DeclarationItemForm.IndicatorList)
                {
                    foreach (var data in OutcomeDataList)
                    {
                        if (data.IndicatorItemId == item.IndicatorItem.Id)
                        {
                            item.IndicatorItem.OutcomeData = data;
                        }
                    }
                }

            }
            catch
            {
            }
        }
    }
}