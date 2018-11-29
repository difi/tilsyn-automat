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
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        [BindProperty]
        [Display(Name = "Välj saksbehandler")]
        public List<SelectListItem> SelectUserList { get; set; }

        [BindProperty]
        [Display(Name = "Välj status")]
        public List<SelectListItem> SelectStatusList { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
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
                        DeadlineDate = DateTime.Now.Date.AddMonths(6),
                        DeclarationTestItem = new DeclarationTestItem
                        {
                            TypeOfMachine = valueListTypeOfMachine.Single(x=>x.Id ==1),
                            TypeOfTest = valueListTypeOfTest.Single(x => x.Id == 1),
                        }
                    };
                }
            }
            catch
            {
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