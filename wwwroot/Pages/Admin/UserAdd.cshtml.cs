using System.Collections.Generic;
using Difi.Sjalvdeklaration.Business;
using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserAddModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public UserItem UserItemForm { get; set; }

        public UserAddModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                UserItemForm = new UserItem
                {
                    RoleListForm = await apiHttpClient.Get<List<RoleItem>>("/api/Role/GetAll")
                };
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
                var result = await apiHttpClient.Post<bool>("/api/User/Add", UserItemForm);

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