using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserAddModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public UserItem UserItemForm { get; set; }

        [BindProperty]
        [Display(Name = "Välj roller")]
        public List<SelectItem> SelectRoleList { get; set; }

        public UserAddModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var list = await apiHttpClient.Get<List<RoleItem>>("/api/Role/GetAll");

                SelectRoleList = list.Where(x => x.IsAdminRole).Select(x => new SelectItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Selected = false
                }).ToList();
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
                var roleList = SelectRoleList.Where(x => x.Selected).Select(x => new RoleItem { Id = x.Id, Name = x.Name }).ToList();
                var result = await apiHttpClient.Post<bool>("/api/User/Add", new UserAddItem {UserItem = UserItemForm, RoleList = roleList});

                if (result)
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