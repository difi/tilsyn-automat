using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;

namespace Log
{
    public class RoleRepositoryLogDecorator : IRoleRepository
    {
        private Guid userId;
        private readonly IRoleRepository inner;

        public RoleRepositoryLogDecorator(IRoleRepository inner)
        {
            this.inner = inner;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
        }

        public ApiResult<T> GetAll<T>() where T : List<RoleItem>
        {
            return inner.GetAll<T>();
        }
    }
}