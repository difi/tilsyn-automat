using System.Linq;
using System.Security.Claims;
using Difi.Sjalvdeklaration.Business;
using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.Pages
{
    public class UserOnlineModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public string Sub { get; set; }

        public UserItem UserItem { get; set; }

        public UserOnlineModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public void OnGet()
        {
            UserItem = apiHttpClient.Get<UserItem>("/api/User/Get/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value).Result;
        }
    }
}