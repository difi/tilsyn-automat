using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public IList<UserItem> UserList { get; private set; }

        public UserItem LocalizationItem { get; set; }

        public UserListModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                UserList = (await apiHttpClient.Get<List<UserItem>>("/api/User/GetAllInternal")).Data;
            }
            catch
            {
            }
        }
    }
}