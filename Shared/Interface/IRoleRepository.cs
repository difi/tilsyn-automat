using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IRoleRepository
    {
        void SetCurrentUser(Guid parse);

        ApiResult<T> GetAll<T>() where T : List<RoleItem>;
    }
}