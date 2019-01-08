using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IConfiguration configuration;

        public CompanyController(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            this.companyRepository = companyRepository;
            this.configuration = configuration;
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
            if (!HandleRequest())
            {
                return new ApiResult<CompanyItem> {Exception = new Exception("Wrong ApiKey!")};
            }

            return companyRepository.Get<CompanyItem>(id);
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
            if (!HandleRequest())
            {
                return new ApiResult<CompanyItem> { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.GetByCorporateIdentityNumber<CompanyItem>(corporateIdentityNumber);
        }

        /// <summary>
        /// Gets all compaies in the system
        /// </summary>
        /// <returns>A list of company items</returns>
        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<CompanyItem>> GetAll()
        {
            if (!HandleRequest())
            {
                return new ApiResult<List<CompanyItem>> { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.GetAll<List<CompanyItem>>();
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.Remove(Guid.Parse(id));
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(CompanyItem companyItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.Add(companyItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(CompanyItem companyItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.Update(companyItem);
        }

        [HttpPost]
        [Route("UpdateCustom")]
        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.UpdateCustom(companyCustomItem);
        }

        [HttpPost]
        [Route("ExcelImport")]
        public ApiResult ExcelImport(ExcelItemRow excelItemRow)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.ExcelImport(excelItemRow);
        }

        [HttpPost]
        [Route("AddLink")]
        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.AddLink(userCompanyItem);
        }

        [HttpPost]
        [Route("RemoveLink")]
        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return companyRepository.RemoveLink(userCompanyItem);
        }

        private bool HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                return false;
            }

            companyRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
            companyRepository.SetCurrentLang(Request.Headers["Lang"]);

            return true;
        }
    }
}