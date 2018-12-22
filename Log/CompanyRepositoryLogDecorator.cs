using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class CompanyRepositoryLogDecorator : ICompanyRepository
    {
        private Guid userId;
        private readonly ICompanyRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);

        public CompanyRepositoryLogDecorator(ICompanyRepository inner, ILogRepository logRepository, IConfiguration configuration)
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

        public ApiResult<T> Get<T>(Guid id) where T : CompanyItem
        {
            var result =  inner.Get<T>(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds> LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetByCorporateIdentityNumber<T>(long corporateIdentityNumber) where T : CompanyItem
        {
            var result = inner.GetByCorporateIdentityNumber<T>(corporateIdentityNumber);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), corporateIdentityNumber, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T : List<CompanyItem>
        {
            var result = inner.GetAll<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult Add(CompanyItem companyItem)
        {
            var companyItemBefore = companyItem.DeepClone();

            var result = inner.Add(companyItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, companyItemBefore));
            }

            return result;
        }

        public ApiResult Update(CompanyItem companyItem)
        {
            var companyItemBefore = companyItem.DeepClone();

            var result = inner.Update(companyItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, companyItemBefore));
            }

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = inner.Remove(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, id));
            }

            return result;
        }

        public ApiResult ExcelImport(ExcelItemRow excelRow)
        {
            var excelRowBefore = excelRow.DeepClone();

            var result = inner.ExcelImport(excelRow);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, excelRowBefore));
            }

            return result;
        }

        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            var userCompanyItemBefore = userCompanyItem.DeepClone();

            var result = inner.AddLink(userCompanyItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, userCompanyItemBefore));
            }

            return result;
        }

        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            var userCompanyItemBefore = userCompanyItem.DeepClone();

            var result = inner.RemoveLink(userCompanyItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, userCompanyItemBefore));
            }

            return result;
        }

        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            var companyCustomItemBefore = companyCustomItem.DeepClone();

            var result = inner.UpdateCustom(companyCustomItem);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, companyCustomItemBefore));
            }

            return result;
        }
    }
}