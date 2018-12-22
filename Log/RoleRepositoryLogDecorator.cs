using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class RoleRepositoryLogDecorator : IRoleRepository
    {
        private Guid userId;
        private readonly IRoleRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);


        public RoleRepositoryLogDecorator(IRoleRepository inner, ILogRepository logRepository, IConfiguration configuration)
        {
            this.inner = inner;
            this.logRepository = logRepository;
            this.configuration = configuration;

            stopwatch.Start();
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }

        public ApiResult<T> GetAll<T>() where T : List<RoleItem>
        {
            var result =  inner.GetAll<T>();

            if (!result.Succeeded && LogError || result.Succeeded && LogGetSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }
    }
}