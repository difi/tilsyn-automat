using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyItem
    {
        public Guid Id { get; set; }

        public String ExternalId { get; set; }

        [Required]
        public String Code { get; set; }

        [Required]
        public String CorporateIdentityNumber { get; set; }

        [Required]
        public String Name { get; set; }

        public String CustomName { get; set; }

        public String MailingAddressStreet { get; set; }

        public String MailingAddressZip { get; set; }

        public String MailingAddressCity { get; set; }

        public String LocationAddressStreet { get; set; }

        public String LocationAddressZip { get; set; }

        public String LocationAddressCity { get; set; }

        public String BusinessAddressStreet { get; set; }

        public String BusinessAddressZip { get; set; }

        public String BusinessAddressCity { get; set; }

        public String IndustryGroupCode { get; set; }

        public String IndustryGroupDescription { get; set; }

        public String IndustryGroupAggregated { get; set; }

        public String InstitutionalSectorCode { get; set; }

        public String InstitutionalSectorDescription { get; set; }

        public String OwenerCorporateIdentityNumber { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }
    }
}