using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class UserRole
    {
        public Guid UserItemId { get; set; }

        public UserItem UserItem { get; set; }

        public Guid RoleItemId { get; set; }

        public RoleItem RoleItem { get; set; }
    }
}