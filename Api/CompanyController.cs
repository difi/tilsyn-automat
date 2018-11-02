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
        [Route("Get/{corporateIdentityNumber}")]
        public CompanyItem Get(string corporateIdentityNumber)
        {
            return companyRepository.Get(corporateIdentityNumber);
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(CompanyItem companyItem)
        {
            return companyRepository.Add(companyItem).Result;
        }

        [HttpPost]
        [Route("ExcelImport")]
        public bool ExcelImport()
        {
            return companyRepository.ExcelImport().Result;
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public bool Remove(string id)
        {
            return companyRepository.Remove(Guid.Parse(id)).Result;
        }
    }
}