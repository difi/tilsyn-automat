using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class CompanyLinkModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public AddLinkToCompanyModel AddLinkToCompany { get; set; }

        public CompanyLinkModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var companyDbItem = (await apiHttpClient.Get<CompanyItem>("/api/Company/GetByCorporateIdentityNumber/" + AddLinkToCompany.CorporateIdentityNumber)).Data;
            var userDbItem = (await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value)).Data;

            if (companyDbItem != null && companyDbItem.Code == AddLinkToCompany.Code)
            {
                var userCompanyItem = new UserCompany
                {
                    CompanyItemId = companyDbItem.Id,
                    UserItemId = userDbItem.Id
                };

                var result = await apiHttpClient.Post<ApiResult>("/api/Company/AddLink", userCompanyItem);

                if (result.Succeeded)
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