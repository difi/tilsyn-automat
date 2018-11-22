using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages
{
    public class UploadTestModel : PageModel
    {
        public void OnGet()
        {
            var test = new FineUploaderAzureServer();
        }
    }
}