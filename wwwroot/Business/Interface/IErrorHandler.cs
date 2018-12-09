using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Business.Interface
{
    public interface IErrorHandler
    {
        Task<IActionResult> View(PageModel pageModel, Task task, Exception exception);

        Task<IActionResult> Log(PageModel pageModel, Task task, Exception exception, object callParameter1 = null, object callParameter2 = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null);
    }
}