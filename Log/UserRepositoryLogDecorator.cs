using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class UserRepositoryLogDecorator : IUserRepository
    {
        private Guid userId;
        private readonly IUserRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);


        public UserRepositoryLogDecorator(IUserRepository inner, ILogRepository logRepository, IConfiguration configuration)
        {
            this.inner = inner;
            this.logRepository = logRepository;
            this.configuration = configuration;

            stopwatch.Start();
        }

        public ApiResult<T> GetAll<T>() where T : List<UserItem>
        {
            var result = inner.GetAll<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetAllInternal<T>() where T : List<UserItem>
        {
            var result = inner.GetAllInternal<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }

        public void SetCurrentLang(string lang)
        {
            inner.SetCurrentLang(lang);
        }

        public ApiResult<T> Get<T>(Guid id) where T : UserItem
        {
            var result = inner.Get<T>(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), id, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> GetByToken<T>(string token) where T : UserItem
        {
            var result = inner.GetByToken<T>(token);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), token, null, result.Data));
            }

            return result;
        }

        public ApiResult<T> Login<T>(string token, long socialSecurityNumber) where T : UserItem
        {
            var result = inner.Login<T>(token, socialSecurityNumber);

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result.GetApiResutlt(), token, socialSecurityNumber, result.Data));
            }

            return result;
        }

        public ApiResult Add(UserItem userItem, List<RoleItem> roleList)
        {
            var userItemBefore = userItem.DeepClone();
            var roleListBefore = roleList.DeepClone();

            var result = inner.Add(userItem, roleList);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result, userItemBefore, roleListBefore));
            }

            return result;
        }

        public ApiResult Update(UserItem userItem, List<RoleItem> roleList)
        {
            var userItemBefore = userItem.DeepClone();
            var roleListBefore = roleList.DeepClone();

            var result = inner.Update(userItem, roleList);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result, userItemBefore, roleListBefore));
            }

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = inner.Remove(id);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, Guid.Empty, result, id));
            }

            return result;
        }
    }
}