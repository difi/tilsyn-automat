using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyController : ApiControllerBase
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(companyRepository, configuration, httpContextAccessor)
        {
            this.companyRepository = companyRepository;
        }

        /// <summary>
        /// Gets a single company by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A company item</returns>
        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<CompanyItem> Get(Guid id)
        {
            return HandleRequest<CompanyItem>() ?? companyRepository.Get<CompanyItem>(id);
        }

        /// <summary>
        /// Gets a single company by CorporateIdentityNumber
        /// </summary>
        /// <param name="corporateIdentityNumber"></param>
        /// <returns>A company item</returns>
        [HttpGet]
        [Route("GetByCorporateIdentityNumber/{corporateIdentityNumber}")]
        public ApiResult<CompanyItem> GetByCorporateIdentityNumber(int corporateIdentityNumber)
        {
            return HandleRequest<CompanyItem>() ?? companyRepository.GetByCorporateIdentityNumber<CompanyItem>(corporateIdentityNumber);
        }

        /// <summary>
        /// Gets all companies in the system
        /// </summary>
        /// <returns>A list of company items</returns>
        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<CompanyItem>> GetAll()
        {
            return HandleRequest<List<CompanyItem>>() ?? companyRepository.GetAll<List<CompanyItem>>();
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            return HandleRequest() ?? companyRepository.Remove(Guid.Parse(id));
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(CompanyItem companyItem)
        {
            return HandleRequest() ?? companyRepository.Add(companyItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(CompanyItem companyItem)
        {
            return HandleRequest() ?? companyRepository.Update(companyItem);
        }

        [HttpPost]
        [Route("UpdateCustom")]
        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            return HandleRequest() ?? companyRepository.UpdateCustom(companyCustomItem);
        }

        [HttpPost]
        [Route("ExcelImport")]
        public ApiResult ExcelImport(ExcelItemRow excelItemRow)
        {
            try
            {
                return HandleRequest() ?? companyRepository.ExcelImport(excelItemRow);
            }
            catch (Exception exception)
            {
                return new ApiResult
                {
                    Exception = exception,
                    Succeeded = false
                };
            }
        }

        [HttpPost]
        [Route("AddLink")]
        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            return HandleRequest() ?? companyRepository.AddLink(userCompanyItem);
        }

        [HttpPost]
        [Route("RemoveLink")]
        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            return HandleRequest() ?? companyRepository.RemoveLink(userCompanyItem);
        }
    }
}