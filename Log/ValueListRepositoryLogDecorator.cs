using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class ValueListRepositoryLogDecorator : IValueListRepository
    {
        private Guid userId;
        private readonly IValueListRepository inner;
        private readonly ILogRepository logRepository;

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }

        public ValueListRepositoryLogDecorator(IValueListRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>
        {
            var result = inner.GetAllTypeOfMachine<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>
        {
            var result = inner.GetAllTypeOfTest<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>
        {
            var result = inner.GetAllTypeOfSupplierAndVersion<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfStatus<T>() where T : List<ValueListTypeOfStatus>
        {
            var result = inner.GetAllTypeOfStatus<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllPurposeOfTest<T>() where T : List<ValueListPurposeOfTest>
        {
            var result = inner.GetAllPurposeOfTest<T>();

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }
    }
}