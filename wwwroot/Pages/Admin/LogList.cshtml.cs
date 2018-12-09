using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class LogListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public List<LogItem> LogList { get; set; }

        public List<UserItem> UserList { get; set; }

        public LogItem LocalizationItem { get; set; }

        public LogListModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            LogList = (await apiHttpClient.Get<List<LogItem>>("/api/Log/GetAll")).Data;
            UserList = (await apiHttpClient.Get<List<UserItem>>("/api/User/GetAll")).Data;

            var noUser = new UserItem
            {
                Id = Guid.Empty,
                Name = "Ej inloggad"
            };

            var unkonwnUser = new UserItem
            {
                Id = Guid.NewGuid(),
                Name = "Okänd"
            };

            UserList.Add(noUser);

            foreach (var logItem in LogList)
            {
                var user = UserList.SingleOrDefault(x => x.Id == logItem.UserId);

                logItem.UserItem = user ?? unkonwnUser;
            }
        }
    }
}