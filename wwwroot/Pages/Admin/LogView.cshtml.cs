using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Log;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    public class LogViewModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        public LogItem LocalizationItem { get; set; }

        public UserItem LocalizationUserItem { get; set; }

        public LogViewModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        public LogItem LogItem { get; private set; }

        public UserItem UserItem { get; private set; }

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
                            await errorHandler.View(this, null, resultUser.Exception);
                        }
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