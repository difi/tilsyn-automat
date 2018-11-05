using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Enhetsregisteret;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Database
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CompanyItem Get(Guid id)
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).SingleOrDefault(x => x.Id == id);
        }

        public CompanyItem GetByCorporateIdentityNumber(string corporateIdentityNumber)
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).SingleOrDefault(x => x.CorporateIdentityNumber == corporateIdentityNumber);
        }

        public IEnumerable<CompanyItem> GetAll()
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).AsNoTracking().ToList();
        }

        public async Task<bool> Add(CompanyItem companyItem)
        {
            if (GetByCorporateIdentityNumber(companyItem.CorporateIdentityNumber) != null)
            {
                return false;
            }

            try
            {
                dbContext.CompanyList.Add(companyItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CompanyItem companyItem)
        {
            try
            {
                var dbItem = Get(companyItem.Id);

                dbItem.Code = companyItem.Code;
                dbItem.Name = companyItem.Name;
                dbItem.CustomName = companyItem.CustomName;
                dbItem.AddressStreet = companyItem.AddressStreet;
                dbItem.AddressZip = companyItem.AddressZip;
                dbItem.AddressCity = companyItem.AddressCity;

                dbContext.ContactPersonList.RemoveRange(dbContext.ContactPersonList.Where(x => x.CompanyItemId == dbItem.Id));

                if (companyItem.ContactPersonList != null && companyItem.ContactPersonList.Any())
                {
                    foreach (var contactPersonItem in companyItem.ContactPersonList)
                    {
                        dbContext.ContactPersonList.Add(new ContactPersonItem {Name = contactPersonItem.Name, Email = contactPersonItem.Email, Phone = contactPersonItem.Phone, CompanyItemId = dbItem.Id});
                    }
                }

                dbContext.CompanyList.Update(dbItem);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Remove(Guid id)
        {
            var dbItem = dbContext.CompanyList.SingleOrDefault(x => x.Id == id);

            if (dbItem == null)
            {
                throw new InvalidOperationException();
            }

            dbContext.CompanyList.Remove(dbItem);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcelImport(ExcelItemRow excelRow)
        {
            try
            {
                if (GetByCorporateIdentityNumber(excelRow.CompanyItem.CorporateIdentityNumber) != null)
                {
                    return false;
                }

                dbContext.CompanyList.Add(excelRow.CompanyItem);
                dbContext.ContactPersonList.Add(excelRow.ContactPersonItem);
                dbContext.DeclarationList.Add(excelRow.DeclarationItem);

                await dbContext.SaveChangesAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddLink(UserCompany userCompanyItem)
        {
            try
            {
                dbContext.UserCompanyList.Add(userCompanyItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}