using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class LogListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<LogListModel> localizer;
        private readonly IApiHttpClient apiHttpClient;

        public List<LogItem> LogList { get; set; }

        public List<UserItem> UserList { get; set; }

        public LogItem LocalizationItem { get; set; }

        public List<SelectListItem> SelectSucceededList { get; set; }

        [BindProperty]
        public FilterModel FilterModel { get; set; }

        public Int32 TotalCount { get; set; }

        public LogListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<LogListModel> localizer)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                CreateLists();

                var resultLog = await apiHttpClient.Get<List<LogItem>>("/api/Log/GetAll");
                var resultUser = await apiHttpClient.Get<List<UserItem>>("/api/User/GetAll");

                if (resultLog.Succeeded && resultUser.Succeeded)
                {
                    FilterModel = new FilterModel
                    {
                        FromDate = DateTime.Now.Date,
                        ToDate = DateTime.Now.Date.AddMonths(1)
                    };

                    LogList = resultLog.Data;
                    UserList = resultUser.Data;

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
                else
                {
                    await errorHandler.View(this, null, !resultLog.Succeeded ? resultLog.Exception : resultUser.Exception);
                }

            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }

        private void CreateLists()
        {
            SelectSucceededList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Text = localizer["All"]
                },
                new SelectListItem
                {
                    Value = "1",
                    Text = localizer["Yes"]
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = localizer["No"]
                }
            };
        }
    }
}