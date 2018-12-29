using System;
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
        private readonly IMemoryCache cache;
        private readonly IDeclarationRepository inner;

        public DeclarationRepositoryCacheDecorator(IMemoryCache cache, IDeclarationRepository inner)
        {
            this.cache = cache;
            this.inner = inner;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            return cache.GetOrCreate("Declaration_Get_" + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.Get<T>(id);
            });
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            return cache.GetOrCreate("Declaration_GetAll", entry =>
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
            return cache.GetOrCreate("Declaration_GetForCompany_" + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                return inner.GetForCompany<T>(id);
            });
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            return cache.GetOrCreate("Declaration_GetOutcomeDataList_" + id, entry =>
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
            cache.Remove("Declaration_Get_" + declarationItemid);
            cache.Remove("Declaration_GetAll");
            cache.Remove("Declaration_GetOutcomeDataList_" + declarationItemid);
            cache.Remove("Declaration_GetForCompany_" + companyItemId);
        }
    }
}
