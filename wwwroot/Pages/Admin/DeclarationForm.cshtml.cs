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

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class DeclarationFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
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

        public DeclarationFormModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id, Guid companyId)
        {
            try
            {
                var userItems = (await apiHttpClient.Get<List<UserItem>>("/api/User/GetAllInternal")).Data;

                SelectUserList = userItems.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = false
                }).ToList();

                var typeOfStatuses = (await apiHttpClient.Get<List<ValueListTypeOfStatus>>("/api/ValueList/GetAllTypeOfStatus")).Data;

                SelectStatusList = typeOfStatuses.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.TextAdmin} - {x.TextCompany} ({x.Text})",
                    Selected = false
                }).ToList();

                var purposeOfTest = (await apiHttpClient.Get<List<ValueListPurposeOfTest>>("/api/ValueList/GetAllPurposeOfTest")).Data;

                SelectPurposeOfTest = purposeOfTest.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Text}",
                    Selected = false
                }).ToList();

                if (id != Guid.Empty)
                {
                    DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
                }
                else
                {
                    var companyItem = (await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + companyId)).Data;

                    var valueListTypeOfMachine = (await apiHttpClient.Get<List<ValueListTypeOfMachine>>("/api/ValueList/GetAllTypeOfMachine")).Data;
                    var valueListTypeOfTest = (await apiHttpClient.Get<List<ValueListTypeOfTest>>("/api/ValueList/GetAllTypeOfTest")).Data;

                    DeclarationItemForm = new DeclarationItem
                    {
                        Company = companyItem,
                        CompanyItemId = companyId,
                        UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                        DeadlineDate = DateTime.Now.Date.AddDays(14).AddHours(23).AddMinutes(59),
                        DeclarationTestItem = new DeclarationTestItem
                        {
                            TypeOfMachine = valueListTypeOfMachine.Single(x=>x.Id ==1),
                            TypeOfTest = valueListTypeOfTest.Single(x => x.Id == 1),
                            PurposeOfTestId = 2
                        }
                    };
                }

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


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
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

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}