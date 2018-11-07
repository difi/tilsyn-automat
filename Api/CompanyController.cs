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
        [Route("GetAll")]
        public IEnumerable<CompanyItem> GetAll()
        {
            return companyRepository.GetAll();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public CompanyItem Get(Guid id)
        {
            return companyRepository.Get(id);
        }

        [HttpGet]
        [Route("GetByCorporateIdentityNumber/{corporateIdentityNumber}")]
        public CompanyItem GetByCorporateIdentityNumber(string corporateIdentityNumber)
        {
            return companyRepository.GetByCorporateIdentityNumber(corporateIdentityNumber);
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
        public bool ExcelImport(ExcelItemRow excelItemRow)
        {
            return companyRepository.ExcelImport(excelItemRow).Result;
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public bool Remove(string id)
        {
            return companyRepository.Remove(Guid.Parse(id)).Result;
        }

        [HttpPost]
        [Route("AddLink")]
        public bool AddLink(UserCompany userCompanyItem)
        {
            return companyRepository.AddLink(userCompanyItem).Result;
        }

        [HttpPost]
        [Route("RemoveLink")]
        public bool RemoveLink(UserCompany userCompanyItem)
        {
            return companyRepository.RemoveLink(userCompanyItem).Result;
        }
    }
}