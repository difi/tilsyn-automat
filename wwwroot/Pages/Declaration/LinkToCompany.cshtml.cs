using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class LinkToCompanyModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public AddLinkToCompanyModel AddLinkToCompany { get; set; }

        public LinkToCompanyModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var idPortenId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var companyDbItem = await apiHttpClient.Get<CompanyItem>("/api/Company/Get/" + AddLinkToCompany.CorporateIdentityNumber);
            var userDbItem = await apiHttpClient.Get<CompanyItem>("/api/User/Get/" + idPortenId);

            if (companyDbItem != null && companyDbItem.Code == AddLinkToCompany.Code)
            {
                var userCompanyItem = new UserCompany
                {
                    CompanyItemId = companyDbItem.Id,
                    UserItemId = userDbItem.Id
                };

                var result = await apiHttpClient.Post<bool>("/api/User/AddLink", userCompanyItem);

                if (result)
                {
                    return RedirectToPage("/Declaration/DeclarationList");
                }

                return Page();
            }

            return Page();
        }
    }

    public class AddLinkToCompanyModel
    {
        [Required]
        public string CorporateIdentityNumber { get; set; }

        [Required]
        public string Code { get; set; }
    }
}