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

        [Display(Name = "Business ID (Supervisory Data Model)")]
        public String ExternalId { get; set; }

        [Display(Name = "Pin code")]
        public String Code { get; set; }

        [Display(Name = "Organization number")]
        public String CorporateIdentityNumber { get; set; }

        [Display(Name = "Organization number of the owner organization")]
        public String OwenerCorporateIdentityNumber { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "Street name and number")]
        public String MailingAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        public String MailingAddressZip { get; set; }

        [Display(Name = "City")]
        public String MailingAddressCity { get; set; }

        [Display(Name = "Street name and number")]
        public String LocationAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        public String LocationAddressZip { get; set; }

        [Display(Name = "City")]
        public String LocationAddressCity { get; set; }

        [Display(Name = "Street name and number")]
        public String BusinessAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        public String BusinessAddressZip { get; set; }

        [Display(Name = "City")]
        public String BusinessAddressCity { get; set; }

        [Display(Name = "Code")]
        public String IndustryGroupCode { get; set; }

        [Display(Name = "Description")]
        public String IndustryGroupDescription { get; set; }

        [Display(Name = "Aggregated")]
        public String IndustryGroupAggregated { get; set; }

        [Display(Name = "Code")]
        public String InstitutionalSectorCode { get; set; }

        [Display(Name = "Description")]
        public String InstitutionalSectorDescription { get; set; }

        [Display(Name = "Changed business name")]
        public String CustomName { get; set; }

        [Display(Name = "Street name and number")]
        public String CustomAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        public String CustomAddressZip { get; set; }

        [Display(Name = "City")]
        public String CustomAddressCity { get; set; }

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

    }
}