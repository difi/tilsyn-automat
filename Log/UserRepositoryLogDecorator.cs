using Difi.Sjalvdeklaration.Shared;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;

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

        public ApiResult<T> GetAllInternal<T>() where T : List<UserItem>
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

        public ApiResult<T> Login<T>(string token, string socialSecurityNumber) where T : UserItem
        {
            var result = inner.Login<T>(token, socialSecurityNumber);

            logRepository.Add(new LogItem(result.GetApiResutlt(), token, socialSecurityNumber, result.Data));

            return result;
        }

        public ApiResult Add(UserItem userItem, List<RoleItem> roleList)
        {
            var result = inner.Add(userItem, roleList);

            logRepository.Add(new LogItem(result, userItem, roleList));

            return result;
        }

        public ApiResult Update(UserItem userItem, List<RoleItem> roleList)
        {
            var result = inner.Update(userItem, roleList);

            logRepository.Add(new LogItem(result, userItem, roleList));

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = inner.Remove(id);

            logRepository.Add(new LogItem(result, id));

            return result;
        }
    }
}