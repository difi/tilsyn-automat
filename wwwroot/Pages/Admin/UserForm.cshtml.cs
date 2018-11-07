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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserFormModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public UserItem UserItemForm { get; set; }

        [BindProperty]
        [Display(Name = "Välj roller")]
        public List<SelectListItem> SelectRoleList { get; set; }

        public UserFormModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var list = await apiHttpClient.Get<List<RoleItem>>("/api/Role/GetAll");

                SelectRoleList = list.Where(x => x.IsAdminRole).Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = false
                }).ToList();

                if (id != Guid.Empty)
                {
                    UserItemForm = await apiHttpClient.Get<UserItem>("/api/User/Get/" + id);

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
                    UserItemForm = new UserItem();
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
                var roleList = SelectRoleList.Where(x => x.Selected).Select(x => new RoleItem {Id = Guid.Parse(x.Value), Name = x.Text}).ToList();
                ApiResult result;

                if (UserItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/User/Update", new UserAddItem { UserItem = UserItemForm, RoleList = roleList });
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/User/Add", new UserAddItem { UserItem = UserItemForm, RoleList = roleList });
                }

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/UserList");
                }

                return Page();
            }
            catch
            {
                return Page();
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

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}