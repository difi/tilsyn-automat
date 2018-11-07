using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Log
{
    public class UserRepositoryLogDecorator : IUserRepository
    {
        private readonly IUserRepository inner;
        private readonly ILogRepository logRepository;

        public UserRepositoryLogDecorator(IUserRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public IEnumerable<UserItem> GetAllInternal()
        {
            return inner.GetAllInternal();
        }

        public UserItem Get(Guid id)
        {
            return inner.Get(id);
        }

        public UserItem GetByToken(string token)
        {
            return inner.GetByToken(token);
        }

        public Task<ApiResult> Add(UserItem userItem, List<RoleItem> roleList)
        {
            var result = inner.Add(userItem, roleList);

            logRepository.Add(new LogItem(result.Result, userItem, roleList));

            return result;
        }

        public Task<ApiResult> Update(UserItem userItem, List<RoleItem> roleList)
        {
            var result = inner.Update(userItem, roleList);

            logRepository.Add(new LogItem(result.Result, userItem, roleList));

            return result;
        }

        public Task<ApiResult> Remove(Guid id)
        {
            var result = inner.Remove(id);

            logRepository.Add(new LogItem(result.Result, id));

            return result;
        }

        public Task<UserItem> Login(string token, string socialSecurityNumber)
        {
            var result = inner.Login(token, socialSecurityNumber);

            logRepository.Add(new LogItem(null, token, socialSecurityNumber, result));

            return result;
        }
    }
}