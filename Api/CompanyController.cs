using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<CompanyItem> Get(Guid id)
        {
            return companyRepository.Get<CompanyItem>(id);
        }

        [HttpGet]
        [Route("GetByCorporateIdentityNumber/{corporateIdentityNumber}")]
        public ApiResult<CompanyItem> GetByCorporateIdentityNumber(string corporateIdentityNumber)
        {
            return companyRepository.GetByCorporateIdentityNumber<CompanyItem>(corporateIdentityNumber);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<IEnumerable<CompanyItem>> GetAll()
        {
            return companyRepository.GetAll<IEnumerable<CompanyItem>>();
        }


        [HttpPost]
        [Route("Add")]
        public ApiResult Add(CompanyItem companyItem)
        {
            return companyRepository.Add(companyItem).Result;
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(CompanyItem companyItem)
        {
            return companyRepository.Update(companyItem).Result;
        }

        [HttpPost]
        [Route("ExcelImport")]
        public ApiResult ExcelImport(ExcelItemRow excelItemRow)
        {
            return companyRepository.ExcelImport(excelItemRow).Result;
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            return companyRepository.Remove(Guid.Parse(id)).Result;
        }

        [HttpPost]
        [Route("AddLink")]
        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            return companyRepository.AddLink(userCompanyItem).Result;
        }

        [HttpPost]
        [Route("RemoveLink")]
        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            return companyRepository.RemoveLink(userCompanyItem).Result;
        }
    }
}