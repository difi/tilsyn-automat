using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class ValueListRepositoryLogDecorator : IValueListRepository
    {
        private Guid userId;
        private readonly IValueListRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);


        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);

            stopwatch.Start(); 
        }

        public ValueListRepositoryLogDecorator(IValueListRepository inner, ILogRepository logRepository, IConfiguration configuration)
        {
            this.inner = inner;
            this.logRepository = logRepository;
            this.configuration = configuration;
        }

        public ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>
        {
            var result = inner.GetAllTypeOfMachine<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>
        {
            var result = inner.GetAllTypeOfTest<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>
        {
            var result = inner.GetAllTypeOfSupplierAndVersion<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfStatus<T>() where T : List<ValueListTypeOfStatus>
        {
            var result = inner.GetAllTypeOfStatus<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllPurposeOfTest<T>() where T : List<ValueListPurposeOfTest>
        {
            var result = inner.GetAllPurposeOfTest<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }
    }
}