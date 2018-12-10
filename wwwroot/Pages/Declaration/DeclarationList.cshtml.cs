using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public CompanyCustomItem CompanyCustomItem { get; set; }

        public CompanyItem CompanyItem { get; private set; }

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
        }

        public void OnGet()
        {
            try
            {
                var userItem = (apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value).Result).Data;
                if (userItem.CompanyList != null && userItem.CompanyList.Any())
                {
                    CompanyItem = userItem.CompanyList.First().CompanyItem;
                    CompanyCustomItem = new CompanyCustomItem
                    {
                        CompanyItemId = CompanyItem.Id,
                        CustomName = string.IsNullOrEmpty(CompanyItem.CustomName) ? CompanyItem.Name : CompanyItem.CustomName,
                        CustomAddressStreet = CompanyItem.CustomAddressStreet,
                        CustomAddressZip = CompanyItem.CustomAddressZip,
                        CustomAddressCity = CompanyItem.CustomAddressCity,
                    };

                    if (string.IsNullOrEmpty(CompanyCustomItem.CustomAddressStreet) && string.IsNullOrEmpty(CompanyCustomItem.CustomAddressZip) && string.IsNullOrEmpty(CompanyCustomItem.CustomAddressStreet))
                    {
                        if (string.IsNullOrEmpty(CompanyItem.OwenerCorporateIdentityNumber))
                        {
                            CompanyCustomItem.CustomAddressStreet = CompanyItem.LocationAddressStreet;
                            CompanyCustomItem.CustomAddressZip = CompanyItem.LocationAddressZip;
                            CompanyCustomItem.CustomAddressCity = CompanyItem.LocationAddressCity;
                        }
                        else
                        {
                            CompanyCustomItem.CustomAddressStreet = CompanyItem.BusinessAddressStreet;
                            CompanyCustomItem.CustomAddressZip = CompanyItem.BusinessAddressZip;
                            CompanyCustomItem.CustomAddressCity = CompanyItem.BusinessAddressCity;
                        }
                    }

                    DeclarationList = new List<DeclarationItem>();
                    var declarationListDb = (apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll").Result).Data;

                    foreach (var declarationItem in declarationListDb)
                    {
                        if (CompanyItem.Id == declarationItem.CompanyItemId)
                        {
                            DeclarationList.Add(declarationItem);
                        }
                    }
                }
                else
                {
                    Response.Redirect("/Declaration/CompanyLink");
                }
            }
            catch (Exception exception)
            {
                apiHttpClient.LogError(exception, CompanyCustomItem);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await apiHttpClient.Post<ApiResult>("/api/Company/UpdateCustom", CompanyCustomItem);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Declaration/DeclarationList");
                }

                return Page();
            }
            catch (Exception exception)
            {
                apiHttpClient.LogError(exception, CompanyCustomItem);

                return Page();
            }
        }
    }
}