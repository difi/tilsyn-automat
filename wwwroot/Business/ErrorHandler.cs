using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public class ErrorHandler : IErrorHandler

    {
        private readonly IApiHttpClient apiHttpClient;

        public ErrorHandler(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task<IActionResult> View(PageModel pageModel, Task task, Exception exception)
        {
            if (exception != null)
            {
                pageModel.ViewData.Add("Error", exception.Message);
            }

            if (task != null)
            {
                await task;
            }

            return pageModel.Page();
        }

        public async Task<IActionResult> Log(PageModel pageModel, Task task, Exception exception, object callParameter1 = null, object callParameter2 = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null)
        {
            apiHttpClient.LogError(exception, callParameter1, callParameter2, callerFunctionName, callerFileName);

            return await View(pageModel, task, exception);
        }
    }
}