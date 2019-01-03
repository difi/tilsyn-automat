using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    public class LogViewModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<LogViewModel> localizer;
        private readonly IApiHttpClient apiHttpClient;

        public LogItem LocalizationItem { get; set; }

        public UserItem LocalizationUserItem { get; set; }

        public LogViewModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<LogViewModel> localizer)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
        }

        public LogItem LogItem { get; private set; }

        public UserItem UserItem { get; private set; }

        public CompanyItem CompanyItem { get; private set; }

        [HttpGet]
        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var resultLog = await apiHttpClient.Get<LogItem>("/api/Log/Get/" + id);

                if (resultLog.Succeeded)
                {
                    LogItem = resultLog.Data;

                    if (LogItem.UserId != Guid.Empty)
                    {
                        var resultUser = await apiHttpClient.Get<UserItem>("/api/User/Get/" + LogItem.UserId);

                        if (resultUser.Succeeded)
                        {
                            UserItem = resultUser.Data;
                        }
                        else
                        {
                            UserItem = new UserItem
                            {
                                Id = Guid.NewGuid(),
                                Name = localizer["Unknown"]
                            };
                        }
                    }
                    else
                    {
                        UserItem = new UserItem
                        {
                            Id = Guid.Empty,
                            Name = localizer["Not logged in"]
                        };
                    }

                    if (LogItem.CompanyId != Guid.Empty)
                    {
                        var resultCompany = await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + LogItem.CompanyId);

                        if (resultCompany.Succeeded)
                        {
                            CompanyItem = resultCompany.Data;
                        }
                        else
                        {
                            CompanyItem = new CompanyItem
                            {
                                Id = Guid.NewGuid(),
                                Name = localizer["Unknown"]
                            };
                        }
                    }
                    else
                    {
                        CompanyItem = new CompanyItem
                        {
                            Id = Guid.Empty,
                            Name = string.Empty
                        };
                    }
                }
                else
                {
                    await errorHandler.View(this, null, resultLog.Exception);
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, id);
            }
        }
    }
}