using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class RoleRepositoryLogDecorator : IRoleRepository
    {
        private readonly IRoleRepository inner;

        public RoleRepositoryLogDecorator(IRoleRepository inner)
        {
            this.inner = inner;
        }

        public void SetCurrentUser(Guid id)
        {
        }

        public ApiResult<T> GetAll<T>() where T : List<RoleItem>
        {
            return inner.GetAll<T>();
        }
    }
}