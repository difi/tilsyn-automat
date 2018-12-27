using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Database.DbContext;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.Database
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDeclarationRepository declarationRepository;
        private readonly IStringLocalizer<CompanyRepository> localizer;

        public CompanyRepository(ApplicationDbContext dbContext, IDeclarationRepository declarationRepository, IStringLocalizer<CompanyRepository> localizer)
        {
            this.dbContext = dbContext;
            this.declarationRepository = declarationRepository;
            this.localizer = localizer;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public ApiResult<T> Get<T>(Guid id) where T : CompanyItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).ThenInclude(x => x.UserItem).Include(x => x.DeclarationList).AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Id = item.Id;
                    result.Succeeded = true;
                }
                else
                {
                    result.Exception = new Exception(localizer["Company with id: {0} doesn't exist.", id]);
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetByCorporateIdentityNumber<T>(long corporateIdentityNumber) where T : CompanyItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).ThenInclude(x => x.UserItem).Include(x => x.DeclarationList).AsNoTracking().SingleOrDefault(x => x.CorporateIdentityNumber == corporateIdentityNumber);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Id = item.Id;
                    result.Succeeded = true;
                }
                else
                {
                    result.Exception = new Exception(localizer["Company with corporate identity number: {0} doesn't exist.", corporateIdentityNumber]);
                }
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

            if (companyItem.CorporateIdentityNumber != null && companyItem.CorporateIdentityNumber > 0)
            {
                var companyItemInDb = dbContext.CompanyList.SingleOrDefault(x => x.CorporateIdentityNumber == companyItem.CorporateIdentityNumber);
                if (companyItemInDb != null)
                {
                    result.Succeeded = false;
                    result.Id = companyItemInDb.Id;
                    result.Exception = new Exception(localizer["A company with corporate identity number: {0} already exist.", companyItem.CorporateIdentityNumber]);

                    return result;
                }
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
                if (companyItem.CorporateIdentityNumber != null && companyItem.CorporateIdentityNumber > 0)
                {
                    var companyItemInDb = dbContext.CompanyList.SingleOrDefault(x => x.CorporateIdentityNumber == companyItem.CorporateIdentityNumber && x.Id != companyItem.Id);
                    if (companyItemInDb != null)
                    {
                        result.Succeeded = false;
                        result.Id = companyItemInDb.Id;
                        result.Exception = new Exception(localizer["A company with corporate identity number: {0} already exist.", companyItem.CorporateIdentityNumber]);

                        return result;
                    }
                }

                var dbItem = dbContext.CompanyList.Single(x => x.Id == companyItem.Id);

                dbItem.Code = companyItem.Code;
                dbItem.ExternalId = companyItem.ExternalId;
                dbItem.CorporateIdentityNumber = companyItem.CorporateIdentityNumber;
                dbItem.OwenerCorporateIdentityNumber = companyItem.OwenerCorporateIdentityNumber;
                dbItem.Name = companyItem.Name;
                dbItem.CustomName = companyItem.CustomName;

                dbItem.MailingAddressStreet = companyItem.MailingAddressStreet;
                dbItem.MailingAddressZip = companyItem.MailingAddressZip;
                dbItem.MailingAddressCity = companyItem.MailingAddressCity;

                dbItem.LocationAddressStreet = companyItem.LocationAddressStreet;
                dbItem.LocationAddressZip = companyItem.LocationAddressZip;
                dbItem.LocationAddressCity = companyItem.LocationAddressCity;

                dbItem.CustomLocationAddressStreet = companyItem.CustomLocationAddressStreet;
                dbItem.CustomLocationAddressZip = companyItem.CustomLocationAddressZip;
                dbItem.CustomLocationAddressCity = companyItem.CustomLocationAddressCity;

                dbItem.BusinessAddressStreet = companyItem.BusinessAddressStreet;
                dbItem.BusinessAddressZip = companyItem.BusinessAddressZip;
                dbItem.BusinessAddressCity = companyItem.BusinessAddressCity;

                dbItem.CustomBusinessAddressStreet = companyItem.CustomBusinessAddressStreet;
                dbItem.CustomBusinessAddressZip = companyItem.CustomBusinessAddressZip;
                dbItem.CustomBusinessAddressCity = companyItem.CustomBusinessAddressCity;

                dbItem.IndustryGroupCode = companyItem.IndustryGroupCode;
                dbItem.IndustryGroupDescription = companyItem.IndustryGroupDescription;
                dbItem.IndustryGroupAggregated = companyItem.IndustryGroupAggregated;

                dbItem.InstitutionalSectorCode = companyItem.InstitutionalSectorCode;
                dbItem.InstitutionalSectorDescription = companyItem.InstitutionalSectorDescription;

                dbContext.ContactPersonList.RemoveRange(dbContext.ContactPersonList.Where(x => x.CompanyItemId == dbItem.Id));

                if (companyItem.ContactPersonList != null && companyItem.ContactPersonList.Any())
                {
                    foreach (var contactPersonItem in companyItem.ContactPersonList)
                    {
                        dbContext.ContactPersonList.Add(new ContactPersonItem { Name = contactPersonItem.Name, Email = contactPersonItem.Email, PhoneCountryCode = contactPersonItem.PhoneCountryCode, Phone = contactPersonItem.Phone, CompanyItemId = dbItem.Id });
                    }
                }

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

                result.Id = id;
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
                if (excelRow.CompanyItem.CorporateIdentityNumber != null && GetByCorporateIdentityNumber<CompanyItem>(excelRow.CompanyItem.CorporateIdentityNumber.Value).Data != null)
                {
                    result.Exception = new Exception(localizer["A company with corporate identity number: {0} already exist.", excelRow.CompanyItem.CorporateIdentityNumber], new Exception("exist"));

                    return result;
                }

                dbContext.CompanyList.Add(excelRow.CompanyItem);
                dbContext.ContactPersonList.Add(excelRow.ContactPersonItem);

                dbContext.SaveChanges();

                result.Id = excelRow.CompanyItem.Id;

                if (excelRow.DeclarationItem == null)
                {
                    result.Succeeded = true;
                }
                else
                {
                    var addDeclarationResult = declarationRepository.Add(excelRow.DeclarationItem);

                    if (addDeclarationResult.Succeeded)
                    {
                        result.Succeeded = true;
                    }
                    else
                    {
                        result.Exception = new Exception("Problem with adding declaration, se inner exception", addDeclarationResult.Exception);
                        result.Succeeded = addDeclarationResult.Succeeded;
                    }
                }
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
                var declarationList = dbContext.DeclarationList.Where(x => x.CompanyItemId == userCompanyItem.CompanyItemId && x.StatusId < 6);
                var companyItem = dbContext.CompanyList.SingleOrDefault(x => x.Id == userCompanyItem.CompanyItemId);

                if (declarationList.Any())
                {
                    dbContext.UserCompanyList.Add(userCompanyItem);
                    dbContext.SaveChanges();

                    result.Id = userCompanyItem.CompanyItemId;
                    result.Succeeded = true;
                }
                else
                {
                    result.Exception = companyItem == null ? new Exception(localizer["No active declarations exist for company"]) : new Exception(localizer["No active declarations exist for {0}", companyItem.Name]);
                    result.Succeeded = false;
                }
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

                    result.Id = userCompanyItem.CompanyItemId;
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

        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.CompanyList.Single(x => x.Id == companyCustomItem.CompanyItemId);

                dbItem.CustomName = companyCustomItem.CustomName;

                dbItem.CustomBusinessAddressStreet = companyCustomItem.CustomBusinessAddressStreet;
                dbItem.CustomBusinessAddressZip = companyCustomItem.CustomBusinessAddressZip;
                dbItem.CustomBusinessAddressCity = companyCustomItem.CustomBusinessAddressCity;

                dbItem.CustomLocationAddressStreet = companyCustomItem.CustomLocationAddressStreet;
                dbItem.CustomLocationAddressZip = companyCustomItem.CustomLocationAddressZip;
                dbItem.CustomLocationAddressCity = companyCustomItem.CustomLocationAddressCity;

                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = dbItem.Id;
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