using System;
using Difi.Sjalvdeklaration.Shared.Classes.Company;

namespace Difi.Sjalvdeklaration.Shared.Classes.User
{
    [Serializable]
    public class UserCompany
    {
        public Guid UserItemId { get; set; }

        public UserItem UserItem { get; set; }

        public Guid CompanyItemId { get; set; }

        public CompanyItem CompanyItem { get; set; }
    }
}