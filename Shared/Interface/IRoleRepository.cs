using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IRoleRepository
    {
        ApiResult<T> GetAll<T>() where T : IEnumerable<RoleItem>;
    }
}