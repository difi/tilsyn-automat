using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Attributes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyItem
    {
        public Guid Id { get; set; }

        [ExcelExport]
        [Display(Name = "Pin code")]
        public string Code { get; set; }

        [ExcelExport]
        [Display(Name = "Business ID (Supervisory Data Model)")]
        public string ExternalId { get; set; }

        [ExcelExport]
        [Display(Name = "Organization number")]
        [RegularExpression("\\d{9}", ErrorMessage = "Organization number must have nine numbers")]
        public long? CorporateIdentityNumber { get; set; }

        [ExcelExport]
        [Display(Name = "Organization number of the owner organization")]
        [RegularExpression("\\d{9}", ErrorMessage = "Organization number of the owner organization must have nine numbers")]
        public long? OwenerCorporateIdentityNumber { get; set; }

        [ExcelExport]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public string Name { get; set; }

        [Display(Name = "Changed business name")]
        public string CustomName { get; set; }

        [ExcelExport("MailingAddress")]
        [Display(Name = "Street name and number")]
        public string MailingAddressStreet { get; set; }

        [ExcelExport("MailingAddress")]
        [Display(Name = "ZIP code")]
        public string MailingAddressZip { get; set; }

        [ExcelExport("MailingAddress")]
        [Display(Name = "City")]
        public string MailingAddressCity { get; set; }

        [ExcelExport("LocationAddress")]
        [Display(Name = "Street name and number")]
        public string LocationAddressStreet { get; set; }

        [ExcelExport("LocationAddress")]
        [Display(Name = "ZIP code")]
        public string LocationAddressZip { get; set; }

        [ExcelExport("LocationAddress")]
        [Display(Name = "City")]
        public string LocationAddressCity { get; set; }

        [ExcelExport("BusinessAddress")]
        [Display(Name = "Street name and number")]
        public string BusinessAddressStreet { get; set; }

        [ExcelExport("BusinessAddress")]
        [Display(Name = "ZIP code")]
        public string BusinessAddressZip { get; set; }

        [ExcelExport("BusinessAddress")]
        [Display(Name = "City")]
        public string BusinessAddressCity { get; set; }

        [ExcelExport("IndustryGroup")]
        [Display(Name = "Code")]
        public string IndustryGroupCode { get; set; }

        [ExcelExport("IndustryGroup")]
        [Display(Name = "Description")]
        public string IndustryGroupDescription { get; set; }

        [ExcelExport("IndustryGroup")]
        [Display(Name = "Aggregated")]
        public string IndustryGroupAggregated { get; set; }

        [ExcelExport("InstitutionalSector")]
        [Display(Name = "Code")]
        public string InstitutionalSectorCode { get; set; }

        [ExcelExport("InstitutionalSector")]
        [Display(Name = "Description")]
        public string InstitutionalSectorDescription { get; set; }

        [ExcelExport("CustomAdress")]
        [Display(Name = "Street name and number")]
        public string CustomAddressStreet { get; set; }

        [ExcelExport("CustomAdress")]
        [Display(Name = "ZIP code")]
        public string CustomAddressZip { get; set; }

        [ExcelExport("CustomAdress")]
        [Display(Name = "City")]
        public string CustomAddressCity { get; set; }

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }

    }
}