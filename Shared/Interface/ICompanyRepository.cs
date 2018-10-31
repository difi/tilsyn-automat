using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ICompanyRepository
    {
        CompanyItem Get(string corporateIdentityNumber);

        IEnumerable<CompanyItem> GetAll();

        Task<bool> Add(CompanyItem companyItem);

        Task<bool> Remove(Guid id);

        Task<bool> ExcelImport();
    }
}