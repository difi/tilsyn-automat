
using Difi.Sjalvdeklaration.Shared.Attributes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyItem
    {
        public Guid Id { get; set; }

        [ExcelExport]
        [Display(Name = "Pin code")]
        [RegularExpression("\\d{4}", ErrorMessage = "Pin code must have four numbers")]
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
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(".+", ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Changed business name")]
        public string CustomName { get; set; }

        [ExcelExport("MailingAddress")]
        [Display(Name = "Street name and number")]
        public string MailingAddressStreet { get; set; }

        [ExcelExport("MailingAddress")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        [Display(Name = "ZIP code")]
        public string MailingAddressZip { get; set; }

        [ExcelExport("MailingAddress")]
        [Display(Name = "City")]
        public string MailingAddressCity { get; set; }

        [ExcelExport("LocationAddress")]
        [Display(Name = "Street name and number")]
        public string LocationAddressStreet { get; set; }

        [ExcelExport("LocationAddress")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        [Display(Name = "ZIP code")]
        public string LocationAddressZip { get; set; }

        [ExcelExport("LocationAddress")]
        [Display(Name = "City")]
        public string LocationAddressCity { get; set; }

        [ExcelExport("CustomLocationAdress")]
        [Display(Name = "Street name and number")]
        public string CustomLocationAddressStreet { get; set; }

        [ExcelExport("CustomLocationAdress")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        [Display(Name = "ZIP code")]
        public string CustomLocationAddressZip { get; set; }

        [ExcelExport("CustomLocationAdress")]
        [Display(Name = "City")]
        public string CustomLocationAddressCity { get; set; }

        [ExcelExport("BusinessAddress")]
        [Display(Name = "Street name and number")]
        public string BusinessAddressStreet { get; set; }

        [ExcelExport("BusinessAddress")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        [Display(Name = "ZIP code")]
        public string BusinessAddressZip { get; set; }

        [ExcelExport("BusinessAddress")]
        [Display(Name = "City")]
        public string BusinessAddressCity { get; set; }

        [ExcelExport("CustomBusinessAdress")]
        [Display(Name = "Street name and number")]
        public string CustomBusinessAddressStreet { get; set; }

        [ExcelExport("CustomBusinessAdress")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        [Display(Name = "ZIP code")]
        public string CustomBusinessAddressZip { get; set; }

        [ExcelExport("CustomBusinessAdress")]
        [Display(Name = "City")]
        public string CustomBusinessAddressCity { get; set; }

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

        public ICollection<UserCompany> UserList { get; set; }

        public ICollection<DeclarationItem> DeclarationList { get; set; }

        public List<ContactPersonItem> ContactPersonList { get; set; }
    }
}