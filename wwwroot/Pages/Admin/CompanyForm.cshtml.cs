using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class CompanyFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public CompanyItem CompanyItemForm { get; set; }

        public CompanyFormModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var result = await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + id);

                    if (result.Succeeded)
                    {
                        CompanyItemForm = result.Data;
                    }
                    else
                    {
                        await errorHandler.View(this, null, result.Exception);
                    }
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
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostSaveAsync(string type)
        {
            if (!ModelState.IsValid)
            {
                return await errorHandler.View(this, OnGetAsync(CompanyItemForm.Id));
            }

            try
            {
                ApiResult result;

                if (CompanyItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Company/Update", CompanyItemForm);
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Company/Add", CompanyItemForm);
                }

                if (result.Succeeded)
                {
                    return type == "declaration" ? RedirectToPage("/Admin/DeclarationForm", new { companyId = result.Id }) : RedirectToPage("/Admin/CompanyList");
                }

                return await errorHandler.View(this, OnGetAsync(CompanyItemForm.Id), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(CompanyItemForm.Id), exception, type);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostRemoveCompanyAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/Company/Remove/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/CompanyList");
                }

                return await errorHandler.View(this, OnGetAsync(Guid.Parse(id)), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(Guid.Parse(id)), exception, id);
            }
        }

        [HttpPost]
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
                    return RedirectToPage("/Admin/CompanyForm", new { id = CompanyItemForm.Id });
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