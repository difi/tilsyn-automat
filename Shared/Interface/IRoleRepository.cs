using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface.Base;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IRoleRepository : IBaseRepository
    {
        ApiResult<T> GetAll<T>() where T : List<RoleItem>;
    }
}