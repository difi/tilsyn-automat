using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.wwwroot.Pages.Admin
{
    [Authorize(Roles = "Administrator,Saksbehandler")]
    public class DeclarationListModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IStringLocalizer<DeclarationListModel> localizer;
        private readonly IExcelGenerator excelGenerator;

        private readonly IApiHttpClient apiHttpClient;

        public IList<DeclarationItem> DeclarationList { get; private set; }

        public DeclarationItem LocalizationItem { get; set; }

        [BindProperty]
        public FilterModel FilterModel { get; set; }

        public List<SelectListItem> SelectStatusList { get; set; }

        public int ViewCount { get; set; }

        [BindProperty]
        public int TotalCount { get; set; }

        public DeclarationListModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IStringLocalizer<DeclarationListModel> localizer, IExcelGenerator excelGenerator)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.localizer = localizer;
            this.excelGenerator = excelGenerator;
        }

        [HttpGet]
        public async Task OnGetAsync()
        {
            try
            {
                if (await CreateLists())
                {
                    var result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");

                    if (result.Succeeded)
                    {
                        DeclarationList = result.Data;

                        ViewCount = DeclarationList.Count;
                        TotalCount = DeclarationList.Count;

                        FilterModel = new FilterModel
                        {
                            FromDate = DateTime.Now.Date,
                            ToDate = DateTime.Now.Date.AddMonths(1),
                            Status = 0
                        };

                        ViewData.Add("ViewAll", true);
                    }
                    else
                    {
                        await errorHandler.View(this, null, result.Exception);
                    }
                }
            }
            catch (Exception exception)
            {
                await errorHandler.Log(this, null, exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostFilterAsync()
        {
            try
            {
                if (await CreateLists())
                {
                    ViewData.Add("ViewAll", false);
                    var result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetByFilter/" + FilterModel.FromDate.Ticks + "/" + FilterModel.ToDate.Ticks + "/" + FilterModel.Status);

                    if (result.Succeeded)
                    {
                        DeclarationList = result.Data;
                        ViewCount = DeclarationList.Count;

                        return Page();
                    }

                    return await errorHandler.View(this, OnGetAsync(), result.Exception);
                }

                return null;
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostViewAllAsync()
        {
            return RedirectToPage("/Admin/DeclarationList");

            //return await errorHandler.View(this, OnGetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> OnPostExportDeclarationListAsync()
        {
            try
            {
                ApiResult<List<DeclarationItem>> result;

                if (Convert.ToBoolean(Request.Form["ViewAll"]))
                {
                    result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetAll");
                }
                else
                {
                    result = await apiHttpClient.Get<List<DeclarationItem>>("/api/Declaration/GetByFilter/" + FilterModel.FromDate.Ticks + "/" + FilterModel.ToDate.Ticks + "/" + FilterModel.Status);
                }

                if (result.Succeeded)
                {
                    var data = excelGenerator.GenerateExcel(result.Data);

                    return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Alla ({DateTime.Now.GetAsFileName()}).xlsx");
                }

                return await errorHandler.View(this, OnGetAsync(), result.Exception);
            }
            catch (Exception exception)
            {
                return await errorHandler.Log(this, OnGetAsync(), exception);
            }
        }

        private async Task<bool> CreateLists()
        {
            var typeOfStatuses = await apiHttpClient.Get<List<ValueListTypeOfStatus>>("/api/ValueList/GetAllTypeOfStatus");

            if (!typeOfStatuses.Succeeded)
            {
                await errorHandler.View(this, null, typeOfStatuses.Exception);

                return false;
            }

            SelectStatusList = typeOfStatuses.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Text}",
                Selected = false
            }).ToList();

            SelectStatusList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = localizer["All"]
            });

            return true;
        }
    }
}