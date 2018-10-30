using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public string LoginUrl { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            LoginUrl = configuration["IdPorten:BaseUrl"] + "/authorize?scope=openid&acr_values=Level3&client_id=" + configuration["IdPorten:ClientId"] + "&redirect_uri=" + configuration["IdPorten:RedirectUrl"] + "&response_type=code&state=login&nonce=" + configuration["IdPorten:Nonce"] + "&ui_locales=nb";
        }
    }
}