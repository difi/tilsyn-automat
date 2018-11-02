using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<RoleItem> GetAll();
    }
}