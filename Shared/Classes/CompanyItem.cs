using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class CompanyItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String CorporateIdentityNumber { get; set; }

        public String Code { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

        public ICollection<UserCompany> UserList { get; set; }
    }
}