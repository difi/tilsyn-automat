using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ICompanyRepository
    {
        CompanyItem Get(string corporateIdentityNumber);

        IEnumerable<CompanyItem> GetAll();

        Task<bool> Add(CompanyItem companyItem);

        Task<bool> Remove(Guid id);

        Task<bool> ExcelImport();

        Task<bool> AddLink(UserCompany userCompanyItem);
    }
}