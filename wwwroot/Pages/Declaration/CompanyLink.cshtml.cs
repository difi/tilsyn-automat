using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class CompanyLinkModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<CompanyLinkModel> localizer;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public AddLinkToCompanyModel AddLinkToCompany { get; set; }

        public bool ViewError { get; set; }

        public CompanyLinkModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<CompanyLinkModel> localizer)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostLinkAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await errorHandler.View(this, null);
                }

                var resultCompany = await apiHttpClient.Get<CompanyItem>("/api/Company/GetByCorporateIdentityNumber/" + AddLinkToCompany.CorporateIdentityNumber);
                var resultUser = await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                if (resultCompany.Data != null && resultCompany.Data.Code == AddLinkToCompany.Code)
                {
                    var userCompanyItem = new UserCompany
                    {
                        CompanyItemId = resultCompany.Data.Id,
                        UserItemId = resultUser.Data.Id
                    };

                    var result = await apiHttpClient.Post<ApiResult>("/api/Company/AddLink", userCompanyItem);

                    if (result.Succeeded)
                    {
                        return RedirectToPage("/Declaration/DeclarationList");
                    }

                    return await errorHandler.View(this, null, result.Exception);
                }

                return await errorHandler.View(this, null, new Exception(localizer["There is no self-inspection available for the organization number you provided. Or you have entered the wrong organization number or PIN code."]));
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, null, exception, AddLinkToCompany);
            }
        }
    }
}