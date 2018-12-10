using System;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class UserListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        public IList<UserItem> UserList { get; private set; }

        public UserItem LocalizationItem { get; set; }

        public UserListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                var result = await apiHttpClient.Get<List<UserItem>>("/api/User/GetAllInternal");

                if (result.Succeeded)
                {
                    UserList = result.Data;
                }
                else
                {
                    await errorHandler.View(this, null, result.Exception);
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }
    }
}