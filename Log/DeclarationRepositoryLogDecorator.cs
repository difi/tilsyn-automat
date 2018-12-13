using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Log;

namespace Difi.Sjalvdeklaration.Log
{
    public class DeclarationRepositoryLogDecorator : IDeclarationRepository
    {
        private Guid userId;
        private readonly IDeclarationRepository inner;
        private readonly ILogRepository logRepository;

        public DeclarationRepositoryLogDecorator(IDeclarationRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            var result = inner.Get<T>(id);

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            var result = inner.GetAll<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetByFilter<T>(FilterModel filterModel) where T : List<DeclarationItem>
        {
            var result = inner.GetByFilter<T>(filterModel);

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), filterModel, null,  result.Data));
            }

            return result;
        }

        public ApiResult<T> GetForCompany<T>(Guid id) where T : List<DeclarationItem>
        {
            var result = inner.GetForCompany<T>(id);

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            var result = inner.GetOutcomeDataList<T>(id);

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult Add(DeclarationItem declarationItem)
        {
            var declarationItemBefore = declarationItem.DeepClone();

            var result = inner.Add(declarationItem);

            logRepository.Add(new LogItem(userId, result, declarationItemBefore));

            return result;
        }

        public ApiResult Update(DeclarationItem declarationItem)
        {
            var declarationItemBefore = declarationItem.DeepClone();

            var result = inner.Update(declarationItem);

            logRepository.Add(new LogItem(userId, result, declarationItemBefore));

            return result;
        }

        public ApiResult Save(Guid declarationItemId, List<OutcomeData> outcomeDataList, DeclarationTestItem declarationTestItem)
        {
            var result = inner.Save(declarationItemId, outcomeDataList, declarationTestItem);

            logRepository.Add(new LogItem(userId, result, declarationItemId, outcomeDataList));

            return result;
        }

        public ApiResult SendIn(Guid id)
        {
            var result = inner.SendIn(id);

            logRepository.Add(new LogItem(userId, result, id));

            return result;
        }

        public ApiResult HaveMachine(Guid id, bool haveMachine)
        {
            var result = inner.HaveMachine(id, haveMachine);

            logRepository.Add(new LogItem(userId, result, id, haveMachine));

            return result;
        }
    }
}