﻿using Difi.Sjalvdeklaration.Shared.Classes;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Declaration
{
    [Authorize(Roles = "Virksomhet")]
    public class DeclarationListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<DeclarationListModel> localizer;
        private readonly IApiHttpClient apiHttpClient;

        [BindProperty]
        public CompanyCustomItem CompanyCustomItem { get; set; }

        public CompanyItem CompanyItem { get; private set; }

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<DeclarationListModel> localizer)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                var result = await apiHttpClient.Get<UserItem>("/api/User/GetByToken/" + User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                if (result.Succeeded)
                {
                    var userItem = result.Data;

                    if (userItem.CompanyList != null && userItem.CompanyList.Any())
                    {
                        CompanyItem = userItem.CompanyList.First().CompanyItem;
                        CompanyCustomItem = new CompanyCustomItem
                        {
                            CompanyItemId = CompanyItem.Id,
                            CustomName = string.IsNullOrEmpty(CompanyItem.CustomName) ? CompanyItem.Name : CompanyItem.CustomName,
                            CustomBusinessAddressStreet = CompanyItem.CustomBusinessAddressStreet,
                            CustomBusinessAddressZip = CompanyItem.CustomBusinessAddressZip,
                            CustomBusinessAddressCity = CompanyItem.CustomBusinessAddressCity,
                            CustomLocationAddressStreet = CompanyItem.CustomLocationAddressStreet,
                            CustomLocationAddressZip = CompanyItem.CustomLocationAddressZip,
                            CustomLocationAddressCity = CompanyItem.CustomLocationAddressCity,
                        };

                        if (CompanyItem.OwenerCorporateIdentityNumber != null && CompanyItem.OwenerCorporateIdentityNumber > 0)
                        {
                            if (string.IsNullOrEmpty(CompanyCustomItem.CustomLocationAddressStreet) && string.IsNullOrEmpty(CompanyCustomItem.CustomLocationAddressZip) && string.IsNullOrEmpty(CompanyCustomItem.CustomLocationAddressStreet))
                            {
                                CompanyCustomItem.CustomLocationAddressStreet = CompanyItem.LocationAddressStreet;
                                CompanyCustomItem.CustomLocationAddressZip = CompanyItem.LocationAddressZip;
                                CompanyCustomItem.CustomLocationAddressCity = CompanyItem.LocationAddressCity;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(CompanyCustomItem.CustomBusinessAddressStreet) && string.IsNullOrEmpty(CompanyCustomItem.CustomBusinessAddressZip) && string.IsNullOrEmpty(CompanyCustomItem.CustomBusinessAddressStreet))
                            {
                                CompanyCustomItem.CustomBusinessAddressStreet = CompanyItem.BusinessAddressStreet;
                                CompanyCustomItem.CustomBusinessAddressZip = CompanyItem.BusinessAddressZip;
                                CompanyCustomItem.CustomBusinessAddressCity = CompanyItem.BusinessAddressCity;
                            }
                        }

                        var resultDeclaration = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetForCompany/" + CompanyItem.Id);

                        if (resultDeclaration.Succeeded)
                        {
                            DeclarationList = resultDeclaration.Data;
                        }
                        else
                        {
                            await errorHandler.View(this, null, resultDeclaration.Exception);
                        }
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
                }
                else
                {
                    await errorHandler.View(this, null, result.Exception);
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception, CompanyCustomItem);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdateCustomAsync()
        {
            if (!ModelState.IsValid)
            {
                return await errorHandler.View(this, OnGetAsync());
            }

            try
            {
                var result = await apiHttpClient.Post<ApiResult>("/api/Company/UpdateCustom", CompanyCustomItem);

                if (result.Succeeded)
                {
                    ViewData.Add("Done", $"<div class='feedback-summary-header'><span>{localizer["Business information have been updated"]}</span></div>");

                    return await errorHandler.View(this, OnGetAsync());
                }

                return await errorHandler.View(this, OnGetAsync(), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception, CompanyCustomItem);
            }
        }
    }
}