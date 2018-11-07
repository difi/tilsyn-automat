using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ICompanyRepository
    {
        ApiResult<T> Get<T>(Guid id) where T : CompanyItem;

        ApiResult<T> GetByCorporateIdentityNumber<T>(string corporateIdentityNumber) where T : CompanyItem;

        ApiResult<T> GetAll<T>() where T : IEnumerable<CompanyItem>;

        Task<ApiResult> Add(CompanyItem companyItem);

        Task<ApiResult> Update(CompanyItem companyItem);

        Task<ApiResult> Remove(Guid id);

        Task<ApiResult> ExcelImport(ExcelItemRow excelRow);

        Task<ApiResult> AddLink(UserCompany userCompanyItem);

        Task<ApiResult> RemoveLink(UserCompany userCompanyItem);
    }
}