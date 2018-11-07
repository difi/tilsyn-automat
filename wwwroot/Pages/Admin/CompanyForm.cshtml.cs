using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class CompanyFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public CompanyItem CompanyItemForm { get; set; }

        public CompanyFormModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    CompanyItemForm = (await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + id)).Data;
                }
                else
                {
                    CompanyItemForm = new CompanyItem
                    {
                        ContactPersonList = new List<ContactPersonItem>
                        {
                            new ContactPersonItem()
                        }
                    };
                }
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostAsync(string type)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                ApiResult<bool> result;

                if (CompanyItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult<bool>>("/api/Company/Update", CompanyItemForm);
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult<bool>>("/api/Company/Add", CompanyItemForm);
                }

                if (result.Succeeded)
                {
                    if (type == "declaration")
                    {
                        return RedirectToPage("/Admin/DeclarationForm", new {companyId = result.Id});
                    }

                    return RedirectToPage("/Admin/CompanyList");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemoveCompanyAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Company/Remove/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/CompanyList");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemoveLinkAsync(string id)
        {
            try
            {
                var user = new UserCompany
                {
                    UserItemId = Guid.Parse(id),
                    CompanyItemId = CompanyItemForm.Id
                };

                var result = await apiHttpClient.Post<ApiResult>("/api/Company/RemoveLink/", user);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/CompanyForm", new {id = CompanyItemForm.Id});
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