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

        public ApiResult<T> GetAllInternal<T>() where T : IEnumerable<UserItem>
        {
            return inner.GetAllInternal<T>();
        }

        public ApiResult<T> Get<T>(Guid id) where T : UserItem
        {
            return inner.Get<T>(id);
        }

        public ApiResult<T> GetByToken<T>(string token) where T : UserItem
        {
            return inner.GetByToken<T>(token);
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

        public Task<ApiResult<T>> Login<T>(string token, string socialSecurityNumber) where T : UserItem
        {
            var result = inner.Login<T>(token, socialSecurityNumber);

            logRepository.Add(new LogItem(null, token, socialSecurityNumber, result));

            return result;
        }
    }
}