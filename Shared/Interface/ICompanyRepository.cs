using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ICompanyRepository
    {
        void SetCurrentUser(Guid parse);

        ApiResult<T> Get<T>(Guid id) where T : CompanyItem;

        ApiResult<T> GetByCorporateIdentityNumber<T>(string corporateIdentityNumber) where T : CompanyItem;

        ApiResult<T> GetAll<T>() where T : List<CompanyItem>;

        ApiResult Add(CompanyItem companyItem);

        ApiResult Update(CompanyItem companyItem);

        ApiResult Remove(Guid id);

        ApiResult ExcelImport(ExcelItemRow excelRow);

        ApiResult AddLink(UserCompany userCompanyItem);

        ApiResult RemoveLink(UserCompany userCompanyItem);
    }
}