using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    public class DeclarationListModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        public IList<CompanyItem> CompanyList { get; private set; }

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationListModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public void OnGet()
        {
            try
            {
                var userItem = apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value).Result;

                CompanyList = new List<CompanyItem>();
                DeclarationList = new List<DeclarationItem>();

                foreach (var userCompany in userItem.CompanyList)
                {
                    CompanyList.Add(userCompany.CompanyItem);
                }

                var declarationListDb = apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll").Result;

                foreach (var declarationItem in declarationListDb)
                {
                    foreach (var companyItem in CompanyList)
                    {
                        if (companyItem.Id == declarationItem.CompanyItemId)
                        {
                            DeclarationList.Add(declarationItem);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}