using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Difi.Sjalvdeklaration.Database
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public ApiResult<T> Get<T>(Guid id) where T : CompanyItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).ThenInclude(x => x.UserItem).Include(x => x.DeclarationList).SingleOrDefault(x => x.Id == id);

                result.Data = (T)item;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetByCorporateIdentityNumber<T>(string corporateIdentityNumber) where T : CompanyItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).ThenInclude(x => x.UserItem).Include(x => x.DeclarationList).SingleOrDefault(x => x.CorporateIdentityNumber == corporateIdentityNumber);

                result.Data = (T)item;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T : List<CompanyItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).ThenInclude(x => x.UserItem).Include(x => x.DeclarationList).AsNoTracking().OrderBy(x => x.Name).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult Add(CompanyItem companyItem)
        {
            var result = new ApiResult();

            if (GetByCorporateIdentityNumber<CompanyItem>(companyItem.CorporateIdentityNumber).Data != null)
            {
                return result;
            }

            try
            {
                companyItem.Id = Guid.NewGuid();

                dbContext.CompanyList.Add(companyItem);
                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = companyItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult Update(CompanyItem companyItem)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get<CompanyItem>(companyItem.Id).Data;

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
                        dbContext.ContactPersonList.Add(new ContactPersonItem { Name = contactPersonItem.Name, Email = contactPersonItem.Email, PhoneCountryCode = contactPersonItem.PhoneCountryCode, Phone = contactPersonItem.Phone, CompanyItemId = dbItem.Id });
                    }
                }

                dbContext.CompanyList.Update(dbItem);

                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = companyItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.CompanyList.SingleOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new InvalidOperationException();
                }

                dbContext.CompanyList.Remove(dbItem);

                dbContext.SaveChanges();

                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult ExcelImport(ExcelItemRow excelRow)
        {
            var result = new ApiResult();

            try
            {
                if (GetByCorporateIdentityNumber<CompanyItem>(excelRow.CompanyItem.CorporateIdentityNumber).Data != null)
                {
                    return result;
                }

                dbContext.CompanyList.Add(excelRow.CompanyItem);
                dbContext.ContactPersonList.Add(excelRow.ContactPersonItem);
                dbContext.DeclarationList.Add(excelRow.DeclarationItem);

                dbContext.SaveChanges();

                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            var result = new ApiResult();

            try
            {
                dbContext.UserCompanyList.Add(userCompanyItem);
                dbContext.SaveChanges();

                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.UserCompanyList.SingleOrDefault(x => x.UserItemId == userCompanyItem.UserItemId && x.CompanyItemId == userCompanyItem.CompanyItemId);

                if (dbItem != null)
                {
                    dbContext.UserCompanyList.Remove(dbItem);
                    dbContext.SaveChanges();

                    result.Succeeded = true;
                }
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }
    }
}