using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class CompanyItem
    {
        public Guid Id { get; set; }

        [Required]
        public String Code { get; set; }

        [Required]
        public String CorporateIdentityNumber { get; set; }

        [Required]
        public String Name { get; set; }

        public String CustomName { get; set; }

        public String AddressStreet { get; set; }

        public String AddressZip { get; set; }

        public String AddressCity { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }
    }
}