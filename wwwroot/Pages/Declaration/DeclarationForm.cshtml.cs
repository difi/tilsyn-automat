using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Declaration;
using Difi.Sjalvdeklaration.Shared.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    [Authorize(Roles = "Virksomhet")]
    public class DeclarationFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public string StorageAccountName { get; set; }

        public string StorageContainer { get; set; }

        public bool AllDoneStep1 { get; set; }

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
                var resultUser = await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                if (!resultUser.Succeeded || resultUser.Data.CompanyList == null || !resultUser.Data.CompanyList.Any())
                {
                    Response.Redirect("/");
                }

                if (await CreateLists())
                {
                    var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id);

                    if (result.Succeeded)
                    {
                        DeclarationItemForm = result.Data;

                        if (DeclarationItemForm.Status.Id == (int)DeclarationStatus.SentIn)
                        {
                            Response.Redirect("/Declaration/DeclarationList");
                        }

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

                var formData = Request.Form.ToDictionary<KeyValuePair<string, StringValues>, string, string>(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
                var declarationTestItem = new DeclarationTestHelper().CreateDeclarationTestItem(formData, DeclarationItemForm.Id, DeclarationItemForm.IndicatorList);

                var result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Save/", new DeclarationSave {Id = DeclarationItemForm.Id, DeclarationTestItem = declarationTestItem });

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
                foreach (var item in TestGroupItemList)
                {
                    item.AllDone = false;
                }

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
    }
}