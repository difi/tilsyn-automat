using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class DeclarationFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IExcelGenerator excelGenerator;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        public List<TestGroupItem> TestGroupItemList { get; set; }

        public bool AllDoneStep1 { get; set; }

        [BindProperty]
        [Display(Name = "Välj saksbehandler")]
        public List<SelectListItem> SelectUserList { get; set; }

        [BindProperty]
        [Display(Name = "Välj status")]
        public List<SelectListItem> SelectStatusList { get; set; }

        [BindProperty]
        [Display(Name = "Välj status")]
        public List<SelectListItem> SelectPurposeOfTest { get; set; }

        public List<ValueListTypeOfMachine> ValueListTypeOfMachine { get; set; }

        public List<ValueListTypeOfTest> ValueListTypeOfTest { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IExcelGenerator excelGenerator)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.excelGenerator = excelGenerator;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id, Guid companyId)
        {
            try
            {
                if (await CreateLists())
                {
                    if (id != Guid.Empty)
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
                    else
                    {
                        var result = await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + companyId);

                        if (result.Succeeded)
                        {
                            DeclarationItemForm = new DeclarationItem
                            {
                                Company = result.Data,
                                CompanyItemId = companyId,
                                UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                                DeadlineDate = DateTime.Now.Date.AddDays(14).AddHours(23).AddMinutes(59),
                                DeclarationTestItem = new DeclarationTestItem
                                {
                                    TypeOfMachine = ValueListTypeOfMachine.Single(x => x.Id == 1),
                                    TypeOfTest = ValueListTypeOfTest.Single(x => x.Id == 1),
                                    PurposeOfTestId = 2
                                }
                            };
                        }
                        else
                        {
                            await errorHandler.View(this, null, result.Exception);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id, companyId);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return await errorHandler.View(this, OnGetAsync(DeclarationItemForm.Id, DeclarationItemForm.CompanyItemId));
            }

            try
            {
                ApiResult result;

                if (DeclarationItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Update", DeclarationItemForm);
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Add", DeclarationItemForm);
                }

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/DeclarationList");
                }

                return await errorHandler.View(this, OnGetAsync(DeclarationItemForm.Id, DeclarationItemForm.CompanyItemId), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(DeclarationItemForm.Id, DeclarationItemForm.CompanyItemId), exception, DeclarationItemForm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostExportDeclarationAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + Guid.Parse(id));

                if (result.Succeeded)
                {
                    var data = excelGenerator.GenerateExcel(new List<DeclarationItem> { result.Data });

                    return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{result.Data.Name} ({DateTime.Now.GetAsFileName()}).xlsx");
                }

                return await errorHandler.View(this, OnGetAsync(DeclarationItemForm.Id, DeclarationItemForm.CompanyItemId), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(DeclarationItemForm.Id, DeclarationItemForm.CompanyItemId), exception, id);
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

            AllDoneStep1 = DeclarationItemForm.DeclarationTestItem.SupplierAndVersionId > 0 && !string.IsNullOrEmpty(DeclarationItemForm.DeclarationTestItem.DescriptionInText) && DeclarationItemForm.DeclarationTestItem.Image1Id != null && DeclarationItemForm.DeclarationTestItem.Image2Id != null;

            foreach (var declarationIndicatorGroup in DeclarationItemForm.IndicatorList.OrderBy(x => x.TestGroupOrder))
            {
                if (TestGroupItemList.Any(x => x.Id == declarationIndicatorGroup.TestGroupItemId))
                {
                    continue;
                }

                var item = declarationIndicatorGroup.TestGroupItem;
                item.AllDone = true;

                TestGroupItemList.Add(item);
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

        private async Task<bool> CreateLists()
        {
            var userItems = await apiHttpClient.Get<List<UserItem>>("/api/User/GetAllInternal");
            var typeOfStatuses = await apiHttpClient.Get<List<ValueListTypeOfStatus>>("/api/ValueList/GetAllTypeOfStatus");
            var purposeOfTest = await apiHttpClient.Get<List<ValueListPurposeOfTest>>("/api/ValueList/GetAllPurposeOfTest");
            var valueListTypeOfMachine = await apiHttpClient.Get<List<ValueListTypeOfMachine>>("/api/ValueList/GetAllTypeOfMachine");
            var valueListTypeOfTest = await apiHttpClient.Get<List<ValueListTypeOfTest>>("/api/ValueList/GetAllTypeOfTest");

            if (!userItems.Succeeded)
            {
                await errorHandler.View(this, null, userItems.Exception);

                return false;
            }

            if (!typeOfStatuses.Succeeded)
            {
                await errorHandler.View(this, null, typeOfStatuses.Exception);

                return false;
            }

            if (!purposeOfTest.Succeeded)
            {
                await errorHandler.View(this, null, purposeOfTest.Exception);

                return false;
            }

            if (!valueListTypeOfMachine.Succeeded)
            {
                await errorHandler.View(this, null, valueListTypeOfMachine.Exception);

                return false;
            }

            if (!valueListTypeOfTest.Succeeded)
            {
                await errorHandler.View(this, null, valueListTypeOfTest.Exception);

                return false;
            }

            SelectUserList = userItems.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            }).ToList();


            SelectStatusList = typeOfStatuses.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.TextAdmin} ({x.Text})",
                Selected = false
            }).ToList();


            SelectPurposeOfTest = purposeOfTest.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Text}",
                Selected = false
            }).ToList();

            ValueListTypeOfTest = valueListTypeOfTest.Data;
            ValueListTypeOfMachine = valueListTypeOfMachine.Data;

            return true;
        }
    }
}