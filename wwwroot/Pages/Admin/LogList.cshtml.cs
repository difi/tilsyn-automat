using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
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

        public List<CompanyItem> CompanyList { get; set; }

        public LogItem LocalizationItem { get; set; }

        public List<SelectListItem> SelectSucceededList { get; set; }

        [BindProperty]
        public FilterModel FilterModel { get; set; }

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
                FilterModel = new FilterModel
                {
                    FromDate = DateTime.Now.Date.AddDays(-14),
                    ToDate = DateTime.Now.Date,
                    Succeeded = 2
                };

                await OnPostFilterAsync();
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostFilterAsync()
        {
            try
            {
                CreateLists();

                var resultLog = await apiHttpClient.Get<List<LogItem>>("/api/Log/GetByFilter/" + FilterModel.FromDate.Ticks + "/" + FilterModel.ToDate.Ticks + "/" + FilterModel.Succeeded);
                var resultUser = await apiHttpClient.Get<List<UserItem>>("/api/User/GetAll");
                var resultCompany = await apiHttpClient.Get<List<CompanyItem>>("/api/Company/GetAll");

                if (resultLog.Succeeded && resultUser.Succeeded && resultCompany.Succeeded)
                {
                    LogList = resultLog.Data;
                    UserList = resultUser.Data;
                    CompanyList = resultCompany.Data;

                    UserList.Add(new UserItem
                    {
                        Id = Guid.Empty,
                        Name = localizer["Not logged in"]
                    });

                    CompanyList.Add(new CompanyItem
                    {
                        Id = Guid.Empty,
                        Name = ""
                    });

                    var unkonwnUser = new UserItem
                    {
                        Id = Guid.NewGuid(),
                        Name = localizer["Unknown"]
                    };

                    var unkonwnCompany = new CompanyItem()
                    {
                        Id = Guid.NewGuid(),
                        Name = localizer["Unknown"]
                    };

                    foreach (var logItem in LogList)
                    {
                        var user = UserList.SingleOrDefault(x => x.Id == logItem.UserId);

                        logItem.UserItem = user ?? unkonwnUser;

                        var company = CompanyList.SingleOrDefault(x => x.Id == logItem.CompanyId);

                        logItem.CompanyItem = company ?? unkonwnCompany;
                    }

                    return Page();
                }

                return await errorHandler.View(this, null, !resultLog.Succeeded ? resultLog.Exception : !resultUser.Succeeded ? resultUser.Exception : resultCompany.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, null, exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostViewAllAsync()
        {
            return RedirectToPage("/Admin/LogList");
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