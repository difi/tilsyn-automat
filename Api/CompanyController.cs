using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;

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
            HandleRequest();

            return companyRepository.Get<CompanyItem>(id);
        }

        [HttpGet]
        [Route("GetByCorporateIdentityNumber/{corporateIdentityNumber}")]
        public ApiResult<CompanyItem> GetByCorporateIdentityNumber(string corporateIdentityNumber)
        {
            HandleRequest();

            return companyRepository.GetByCorporateIdentityNumber<CompanyItem>(corporateIdentityNumber);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<CompanyItem>> GetAll()
        {
            HandleRequest();

            return companyRepository.GetAll<List<CompanyItem>>();
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(CompanyItem companyItem)
        {
            HandleRequest();

            return companyRepository.Add(companyItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(CompanyItem companyItem)
        {
            HandleRequest();

            return companyRepository.Update(companyItem);
        }

        [HttpPost]
        [Route("ExcelImport")]
        public ApiResult ExcelImport(ExcelItemRow excelItemRow)
        {
            HandleRequest();

            return companyRepository.ExcelImport(excelItemRow);
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            HandleRequest();

            return companyRepository.Remove(Guid.Parse(id));
        }

        [HttpPost]
        [Route("AddLink")]
        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            HandleRequest();

            return companyRepository.AddLink(userCompanyItem);
        }

        [HttpPost]
        [Route("RemoveLink")]
        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            HandleRequest();

            return companyRepository.RemoveLink(userCompanyItem);
        }

        private void HandleRequest()
        {
            companyRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}