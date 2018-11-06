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

        Task<bool> Add(CompanyItem companyItem);

        Task<bool> Update(CompanyItem companyItem);

        Task<bool> Remove(Guid id);

        Task<bool> ExcelImport(ExcelItemRow excelRow);

        Task<bool> AddLink(UserCompany userCompanyItem);

        Task<bool> RemoveLink(UserCompany userCompanyItem);
    }
}