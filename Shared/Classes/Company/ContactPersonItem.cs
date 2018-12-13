using System;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Attributes;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class ContactPersonItem
    {
        public Guid Id { get; set; }

        [ExcelExport]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [ExcelExport]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ExcelExport]
        [Display(Name = "Country code")]
        public string PhoneCountryCode { get; set; }

        [ExcelExport]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public Guid CompanyItemId { get; set; }
    }
}