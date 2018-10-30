using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Business;
using Microsoft.AspNetCore.Authorization;

namespace Difi.Sjalvdeklaration.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationListModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationListModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                DeclarationList = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");
            }
            catch
            {
            }
        }
    }
}