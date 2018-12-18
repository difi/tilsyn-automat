using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Microsoft.AspNetCore.Authorization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    [Authorize(Roles = "Virksomhet")]
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
                var resultUser = await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                if (!resultUser.Succeeded || resultUser.Data.CompanyList == null || !resultUser.Data.CompanyList.Any())
                {
                    Response.Redirect("/");
                }

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
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
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

            if (!result.Data.Any())
            {
                return true;
            }

            foreach (var item in DeclarationItemForm.IndicatorList)
            {
                foreach (var data in result.Data)
                {
                    if (data.IndicatorItemId != item.IndicatorItem.Id)
                    {
                        continue;
                    }

                    item.IndicatorItem.OutcomeData = data;

                    if (data.AllDone)
                    {
                        continue;
                    }

                    foreach (var indicatorTestGroup in data.Indicator.TestGroupList)
                    {
                        var testGroup = TestGroupItemList.Single(x => x.Id == indicatorTestGroup.TestGroupItemId);
                        testGroup.AllDone = false;
                    }
                }
            }

            return true;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostSendInAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Declaration/SendIn/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationThanks", new {id});
                }

                return await errorHandler.View(this, OnGetAsync(Guid.Parse(id)), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(Guid.Parse(id)), exception, id);
            }
        }
    }
}