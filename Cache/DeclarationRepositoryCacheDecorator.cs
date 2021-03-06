﻿using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace Cache
{
    public class DeclarationRepositoryCacheDecorator: IDeclarationRepository
    {
        private string currentLang;
        private readonly IMemoryCache cache;
        private readonly IDeclarationRepository inner;

        public DeclarationRepositoryCacheDecorator(IMemoryCache cache, IDeclarationRepository inner)
        {
            this.cache = cache;
            this.inner = inner;
        }

        public void SetCurrentUser(Guid userGuid)
        {
            inner.SetCurrentUser(userGuid);
        }

        public void SetCurrentLang(string lang)
        {
            currentLang = lang;
            inner.SetCurrentLang(lang);
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            return cache.GetOrCreate("Declaration_Get_" + currentLang + "_" + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.Get<T>(id);
            });
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            return cache.GetOrCreate("Declaration_GetAll_" + currentLang, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.GetAll<T>();
            });
        }

        public ApiResult<T> GetByFilter<T>(FilterModel filterModel) where T : List<DeclarationItem>
        {
            return inner.GetByFilter<T>(filterModel);
        }

        public ApiResult<T> GetForCompany<T>(Guid id) where T : List<DeclarationItem>
        {
            return cache.GetOrCreate("Declaration_GetForCompany_" + currentLang + "_" + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.GetForCompany<T>(id);
            });
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            return cache.GetOrCreate("Declaration_GetOutcomeDataList_" + currentLang + "_" + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.GetOutcomeDataList<T>(id);
            });
        }

        public ApiResult Add(DeclarationItem declarationItem)
        {
            ClearCache(declarationItem.Id, declarationItem.CompanyItemId);

            return inner.Add(declarationItem);
        }

        public ApiResult Update(DeclarationItem declarationItem)
        {
            ClearCache(declarationItem.Id, declarationItem.CompanyItemId);

            return inner.Update(declarationItem);
        }

        public ApiResult<T> Save<T>(Guid declarationItemId, Guid companyItemId, DeclarationTestItem declarationTestItem) where T : DeclarationSaveResult
        {
            ClearCache(declarationItemId, companyItemId);

            return inner.Save<T>(declarationItemId, companyItemId, declarationTestItem);
        }

        public ApiResult SendIn(Guid declarationItemId, Guid companyItemId)
        {
            ClearCache(declarationItemId, companyItemId);

            return inner.SendIn(declarationItemId, companyItemId);
        }

        public ApiResult HaveMachine(Guid declarationItemId, Guid companyItemId, bool haveMachine)
        {
            ClearCache(declarationItemId, companyItemId);

            return inner.HaveMachine(declarationItemId, companyItemId, haveMachine);
        }

        private void ClearCache(Guid declarationItemid, Guid companyItemId)
        {
            const string currentLangNb = "nb-NO";
            const string currentLangNn = "nn-NO";

            cache.Remove("Declaration_Get_" + currentLangNb + "_" + declarationItemid);
            cache.Remove("Declaration_GetAll_" + currentLangNb);
            cache.Remove("Declaration_GetOutcomeDataList_" + currentLangNb + "_" + declarationItemid);
            cache.Remove("Declaration_GetForCompany_" + currentLangNb + "_" + companyItemId);

            cache.Remove("Declaration_Get_" + currentLangNn + "_" + declarationItemid);
            cache.Remove("Declaration_GetAll_" + currentLangNn);
            cache.Remove("Declaration_GetOutcomeDataList_" + currentLangNn + "_" + declarationItemid);
            cache.Remove("Declaration_GetForCompany_" + currentLangNn + "_" + companyItemId);
        }
    }
}
