using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class UserRole
    {
        public Guid UserItemId { get; set; }

        public UserItem UserItem { get; set; }

        public Guid RoleItemId { get; set; }

        public RoleItem RoleItem { get; set; }
    }
}


namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class UserCompany
    {
        public Guid UserItemId { get; set; }

        public UserItem UserItem { get; set; }

        public Guid CompanyItemId { get; set; }

        public CompanyItem CompanyItem { get; set; }
    }
}