using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace Cache
{
    public class CompanyRepositoryCacheDecorator: ICompanyRepository
    {
        private string currentLang;
        private readonly IMemoryCache cache;
        private readonly ICompanyRepository inner;

        public CompanyRepositoryCacheDecorator(IMemoryCache cache, ICompanyRepository inner)
        {
            this.cache = cache;
            this.inner = inner;
        }

        public void SetCurrentLang(string lang)
        {
            currentLang = lang;
            inner.SetCurrentLang(lang);
        }

        public void SetCurrentUser(Guid parse)
        {
            inner.SetCurrentUser(parse);
        }

        public ApiResult<T> Get<T>(Guid id) where T : CompanyItem
        {
            return inner.Get<T>(id);
        }

        public ApiResult<T> GetByCorporateIdentityNumber<T>(long corporateIdentityNumber) where T : CompanyItem
        {
            return inner.GetByCorporateIdentityNumber<T>(corporateIdentityNumber);
        }

        public ApiResult<T> GetAll<T>() where T : List<CompanyItem>
        {
            return inner.GetAll<T>();
        }

        public ApiResult Add(CompanyItem companyItem)
        {
            ClearCache(Guid.Empty);

            return inner.Add(companyItem);
        }

        public ApiResult Update(CompanyItem companyItem)
        {
            return inner.Update(companyItem);
        }

        public ApiResult Remove(Guid id)
        {
            ClearCache(id);

            return inner.Remove(id);
        }

        public ApiResult ExcelImport(ExcelItemRow excelRow)
        {
            ClearCache(Guid.Empty);

            return inner.ExcelImport(excelRow);
        }

        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            return inner.AddLink(userCompanyItem);
        }

        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            return inner.RemoveLink(userCompanyItem);
        }

        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            return inner.UpdateCustom(companyCustomItem);
        }

        private void ClearCache(Guid companyItemId)
        {
            const string currentLangNb = "nb-NO";
            const string currentLangNn = "nn-NO";

            cache.Remove("Declaration_GetAll_" + currentLangNb);
            cache.Remove("Declaration_GetForCompany_" + currentLangNb + "_" + companyItemId);

            cache.Remove("Declaration_GetAll_" + currentLangNn);
            cache.Remove("Declaration_GetForCompany_" + currentLangNn + "_" + companyItemId);
        }
    }
}
