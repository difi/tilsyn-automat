using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    public class LogViewModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        public LogItem LocalizationItem { get; set; }

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
            LogItem = (await apiHttpClient.Get<LogItem>("/api/Log/Get/"+id)).Data;

            if (LogItem.UserId != Guid.Empty)
            {
                UserItem = (await apiHttpClient.Get<UserItem>("/api/User/Get/" + LogItem.Id)).Data;
            }


        }
    }
}