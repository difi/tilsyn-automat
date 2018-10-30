using Difi.Sjalvdeklaration.Business;
using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserListModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public IList<UserItem> UserList { get; private set; }

        public UserListModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                UserList = await apiHttpClient.Get<List<UserItem>>("/api/User/GetAll");
            }
            catch
            {
            }
        }
    }
}