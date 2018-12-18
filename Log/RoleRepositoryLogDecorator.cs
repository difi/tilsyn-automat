using System;
using System.Collections.Generic;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class RoleRepositoryLogDecorator : IRoleRepository
    {
        private Guid userId;
        private readonly IRoleRepository inner;
        private readonly ILogRepository logRepository;
        private readonly Stopwatch stopwatch = new Stopwatch();

        public RoleRepositoryLogDecorator(IRoleRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;

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

            if (!result.Succeeded)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result.GetApiResutlt(), null, null, result.Data));
            }

            return result;
        }
    }
}