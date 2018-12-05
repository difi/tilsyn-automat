using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationListModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        public CompanyItem CompanyItem { get; private set; }

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationItem LocalizationItem { get; set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public void OnGet()
        {
            try
            {
                var userItem = (apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value).Result).Data;

                if (userItem.CompanyList != null && userItem.CompanyList.Any())
                {
                    CompanyItem = userItem.CompanyList.First().CompanyItem;

                    DeclarationList = new List<DeclarationItem>();
                    var declarationListDb = (apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll").Result).Data;

                    foreach (var declarationItem in declarationListDb)
                    {
                        //if (CompanyItem.Id == declarationItem.CompanyItemId)
                        //{
                            DeclarationList.Add(declarationItem);
                        //}
                    }
                }
                else
                {
                    Response.Redirect("/Declaration/CompanyLink");
                }
            }
            catch
            {
            }
        }
    }
}