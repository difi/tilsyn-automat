using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class UserItem
    {
        public Guid Id { get; set; }

        public String IdPortenSub { get; set; }

        public String SocialSecurityNumber { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public ICollection<UserRole> RoleList { get; set; }

        public ICollection<UserCompany> CompanyList { get; set; }
    }
}