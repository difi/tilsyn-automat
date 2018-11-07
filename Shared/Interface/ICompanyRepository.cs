using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ICompanyRepository
    {
        CompanyItem Get(Guid id);

        CompanyItem GetByCorporateIdentityNumber(string corporateIdentityNumber);

        IEnumerable<CompanyItem> GetAll();

        Task<ApiResult> Add(CompanyItem companyItem);

        Task<ApiResult> Update(CompanyItem companyItem);

        Task<ApiResult> Remove(Guid id);

        Task<ApiResult> ExcelImport(ExcelItemRow excelRow);

        Task<ApiResult> AddLink(UserCompany userCompanyItem);

        Task<ApiResult> RemoveLink(UserCompany userCompanyItem);
    }
}