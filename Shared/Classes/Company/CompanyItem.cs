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

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Code - required field")]
        public String Code { get; set; }

        [Display(Name = "CorporateIdentityNumber")]
        [Required(ErrorMessage = "CorporateIdentityNumber - required field")]
        public String CorporateIdentityNumber { get; set; }

        [Display(Name = "OwnerCorporateIdentityNumber")]
        public String OwenerCorporateIdentityNumber { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "MailingAddressStreet")]
        [Required(ErrorMessage = "MailingAddressStreet - required field")]
        public String MailingAddressStreet { get; set; }

        [Display(Name = "MailingAddressZip")]
        [Required(ErrorMessage = "MailingAddressZip - required field")]
        public String MailingAddressZip { get; set; }

        [Display(Name = "MailingAddressCity")]
        [Required(ErrorMessage = "MailingAddressCity - required field")]
        public String MailingAddressCity { get; set; }

        [Display(Name = "LocationAddressStreet")]
        [Required(ErrorMessage = "LocationAddressStreet - required field")]
        public String LocationAddressStreet { get; set; }

        [Display(Name = "LocationAddressZip")]
        [Required(ErrorMessage = "LocationAddressZip - required field")]
        public String LocationAddressZip { get; set; }

        [Display(Name = "LocationAddressCity")]
        [Required(ErrorMessage = "LocationAddressCity - required field")]
        public String LocationAddressCity { get; set; }

        [Display(Name = "BusinessAddressStreet")]
        [Required(ErrorMessage = "BusinessAddressStreet - required field")]
        public String BusinessAddressStreet { get; set; }

        [Display(Name = "BusinessAddressZip")]
        [Required(ErrorMessage = "BusinessAddressZip - required field")]
        public String BusinessAddressZip { get; set; }

        [Display(Name = "BusinessAddressCity")]
        [Required(ErrorMessage = "BusinessAddressCity - required field")]
        public String BusinessAddressCity { get; set; }

        [Display(Name = "IndustryGroupCode")]
        [Required(ErrorMessage = "IndustryGroupCode - required field")]
        public String IndustryGroupCode { get; set; }

        [Display(Name = "IndustryGroupDescription")]
        [Required(ErrorMessage = "IndustryGroupDescription - required field")]
        public String IndustryGroupDescription { get; set; }

        [Display(Name = "IndustryGroupAggregated")]
        [Required(ErrorMessage = "IndustryGroupAggregated - required field")]
        public String IndustryGroupAggregated { get; set; }

        [Display(Name = "InstitutionalSectorCode")]
        [Required(ErrorMessage = "InstitutionalSectorCode - required field")]
        public String InstitutionalSectorCode { get; set; }

        [Display(Name = "InstitutionalSectorDescription")]
        [Required(ErrorMessage = "InstitutionalSectorDescription - required field")]
        public String InstitutionalSectorDescription { get; set; }

        [Display(Name = "CustomName")]
        //[Required(ErrorMessage = "CustomName - required field")]
        public String CustomName { get; set; }

        [Display(Name = "CustomAddressStreet")]
        //[Required(ErrorMessage = "CustomAddressStreet - required field")]
        public String CustomAddressStreet { get; set; }

        [Display(Name = "CustomAddressZip")]
        //[Required(ErrorMessage = "CustomAddressZip - required field")]
        public String CustomAddressZip { get; set; }

        [Display(Name = "CustomAddressCity")]
        //[Required(ErrorMessage = "CustomAddressCity - required field")]
        public String CustomAddressCity { get; set; }

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

    }
}