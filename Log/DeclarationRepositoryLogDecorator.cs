using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class DeclarationRepositoryLogDecorator : IDeclarationRepository
    {
        private Guid userId;
        private readonly IDeclarationRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);

        public DeclarationRepositoryLogDecorator(IDeclarationRepository inner, ILogRepository logRepository, IConfiguration configuration)
        {
            this.inner = inner;
            this.logRepository = logRepository;
            this.configuration = configuration;

            stopwatch.Start();
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            var result = inner.Get<T>(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            var result = inner.GetAll<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetByFilter<T>(FilterModel filterModel) where T : List<DeclarationItem>
        {
            var result = inner.GetByFilter<T>(filterModel);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), filterModel, null,  result.Data));
            }

            return result;
        }

        public ApiResult<T> GetForCompany<T>(Guid id) where T : List<DeclarationItem>
        {
            var result = inner.GetForCompany<T>(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            var result = inner.GetOutcomeDataList<T>(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult Add(DeclarationItem declarationItem)
        {
            var declarationItemBefore = declarationItem.DeepClone();

            var result = inner.Add(declarationItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, declarationItemBefore));
            }

            return result;
        }

        public ApiResult Update(DeclarationItem declarationItem)
        {
            var declarationItemBefore = declarationItem.DeepClone();

            var result = inner.Update(declarationItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, declarationItemBefore));
            }

            return result;
        }

        public ApiResult<T> Save<T>(Guid declarationItemId, Guid companyId, DeclarationTestItem declarationTestItem) where T : DeclarationSaveResult
        {
            var beforeSave = declarationTestItem.DeepClone();

            var result = inner.Save<T>(declarationItemId, companyId, declarationTestItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), declarationItemId, beforeSave));
            }

            return result;
        }

        public ApiResult SendIn(Guid declarationItemId, Guid companyId)
        {
            var result = inner.SendIn(declarationItemId, companyId);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, declarationItemId));
            }

            return result;
        }

        public ApiResult HaveMachine(Guid declarationItemId, Guid companyId, bool haveMachine)
        {
            var result = inner.HaveMachine(declarationItemId, companyId, haveMachine);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, declarationItemId, haveMachine));
            }

            return result;
        }
    }
}