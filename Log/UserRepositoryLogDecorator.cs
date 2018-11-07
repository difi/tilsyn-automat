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

        public UserRepositoryLogDecorator(IUserRepository inner)
        {
            this.inner = inner;
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
            return inner.Add(userItem, roleList);
        }

        public Task<ApiResult> Update(UserItem userItem, List<RoleItem> roleList)
        {
            return inner.Update(userItem, roleList);
        }

        public Task<ApiResult> Remove(Guid parse)
        {
            return inner.Remove(parse);
        }

        public Task<UserItem> Login(string token, string socialSecurityNumber)
        {
            return inner.Login(token, socialSecurityNumber);
        }
    }
}