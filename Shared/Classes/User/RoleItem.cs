using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.User
{
    [Serializable]
    public class RoleItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public Boolean IsAdminRole { get; set; }

        public ICollection<UserRole> UserList { get; set; }
    }
}