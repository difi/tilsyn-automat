using System.Collections.Generic;
using Difi.Sjalvdeklaration.Business;
using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Difi.Sjalvdeklaration.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class AddCompanyModel : PageModel
    {
        private readonly ApiHttpClient apiHttpClient;

        [BindProperty]
        public AddCompanyFormModel AddCompanyForm { get; set; }

        public AddCompanyModel(ApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var companyItem = new CompanyItem
            {
                CorporateIdentityNumber = AddCompanyForm.CorporateIdentityNumber,
                Code = AddCompanyForm.Code,
                ContactPersonList = new List<ContactPersonItem>
                {
                    new ContactPersonItem
                    {
                        Name = AddCompanyForm.ContactPersonName,
                        Email = AddCompanyForm.ContactPersonEmail,
                        Phone = AddCompanyForm.ContactPersonPhone
                    }
                }
            };

            try
            {
                var result = await apiHttpClient.Post<bool>("/api/Company/Add", companyItem);

                if (result)
                {
                    return RedirectToPage("/Admin/CompanyList");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }

    public class AddCompanyFormModel
    {
        [Required]
        public string CorporateIdentityNumber { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string ContactPersonName { get; set; }

        [Required]
        public string ContactPersonEmail { get; set; }

        [Required]
        public string ContactPersonPhone { get; set; }
    }
}