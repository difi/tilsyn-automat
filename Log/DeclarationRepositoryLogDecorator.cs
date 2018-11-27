using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

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
            return inner.Get<T>(id);
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            return inner.GetAll<T>();
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            return inner.GetOutcomeDataList<T>(id);
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

        public ApiResult Save(Guid declarationItemId, List<OutcomeData> outcomeDataList)
        {
            var result = inner.Save(declarationItemId, outcomeDataList);

            logRepository.Add(new LogItem(userId, result, declarationItemId, outcomeDataList));

            return result;
        }

        public ApiResult SendIn(Guid id)
        {
            var result = inner.SendIn(id);

            logRepository.Add(new LogItem(userId, result, id));

            return result;
        }
    }
}