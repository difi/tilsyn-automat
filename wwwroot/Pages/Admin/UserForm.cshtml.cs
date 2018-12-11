using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class UserFormModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public UserItem UserItemForm { get; set; }

        [BindProperty]
        [Display(Name = "Select roles")]
        public List<SelectListItem> SelectRoleList { get; set; }

        public UserFormModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var resultRole = await apiHttpClient.Get<List<RoleItem>>("/api/Role/GetAll");

                if (resultRole.Succeeded)
                {
                    SelectRoleList = resultRole.Data.Where(x => x.IsAdminRole).Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                        Selected = false
                    }).ToList();
                }
                else
                {
                    await errorHandler.View(this, null, resultRole.Exception);
                }

                if (id != Guid.Empty)
                {
                    var resultUser = await apiHttpClient.Get<UserItem>("/api/User/Get/" + id);

                    if (resultUser.Succeeded)
                    {
                        UserItemForm = resultUser.Data;

                        foreach (var userRole in UserItemForm.RoleList)
                        {
                            foreach (var selectItem in SelectRoleList)
                            {
                                if (userRole.RoleItemId == Guid.Parse(selectItem.Value))
                                {
                                    selectItem.Selected = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        await errorHandler.View(this, null, resultUser.Exception);
                    }
                }
                else
                {
                    UserItemForm = new UserItem();
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
            }
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return await errorHandler.View(this, OnGetAsync(UserItemForm.Id));
            }

            try
            {
                ApiResult result;
                var roleList = SelectRoleList.Where(x => x.Selected).Select(x => new RoleItem {Id = Guid.Parse(x.Value), Name = x.Text}).ToList();

                if (UserItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/User/Update", new UserAddItem {UserItem = UserItemForm, RoleList = roleList});
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/User/Add", new UserAddItem {UserItem = UserItemForm, RoleList = roleList});
                }

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/UserList");
                }

                return await errorHandler.View(this, OnGetAsync(UserItemForm.Id), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(UserItemForm.Id), exception, UserItemForm, SelectRoleList);
            }
        }

        public async Task<IActionResult> OnPostRemoveUserAsync(string id)
        {
            try
            {
                var result = await apiHttpClient.Get<ApiResult>("/api/User/Remove/" + id);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/UserList");
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