using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Admin,Saksbehandlare")]
    public class DeclarationFormModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public DeclarationItem DeclarationItemForm { get; set; }

        [BindProperty]
        [Display(Name = "Välj saksbehandler")]
        public List<SelectListItem> SelectUserList { get; set; }

        public DeclarationFormModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        [HttpGet]
        public async Task OnGetAsync(Guid id, Guid companyId)
        {
            try
            {
                var list = (await apiHttpClient.Get<List<UserItem>>("/api/User/GetAllInternal")).Data;

                SelectUserList = list.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = false
                }).ToList();

                if (id != Guid.Empty)
                {
                    DeclarationItemForm = (await apiHttpClient.Get<DeclarationItem>("/api/Declaration/Get/" + id)).Data;
                }
                else
                {
                    DeclarationItemForm = new DeclarationItem
                    {
                        CompanyItemId = companyId,
                        UserItemId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
                        DeadlineDate = DateTime.Now.Date.AddMonths(6)
                        
                    };
                }
            }
            catch
            {
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
                ApiResult result;

                if (DeclarationItemForm.Id != Guid.Empty)
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Update", DeclarationItemForm);
                }
                else
                {
                    result = await apiHttpClient.Post<ApiResult>("/api/Declaration/Add", DeclarationItemForm);
                }

                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/DeclarationList");
                }

                return Page();
            }
            catch
            {
                return Page();
            }
        }
    }
}