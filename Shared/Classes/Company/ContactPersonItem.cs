using Difi.Sjalvdeklaration.Shared.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class ContactPersonItem
    {
        public Guid Id { get; set; }

        [ExcelExport]
        [Display(Name = "Name")]
        [AutoComplete("off")]
        public string Name { get; set; }

        [ExcelExport]
        [RegularExpression("[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "You need to type a correct email address")]
        [AutoComplete("off")]
        public string Email { get; set; }

        [ExcelExport]
        [Display(Name = "Country code")]
        [AutoComplete("off")]
        public string PhoneCountryCode { get; set; }

        [ExcelExport]
        [Display(Name = "Phone")]
        [AutoComplete("off")]
        public string Phone { get; set; }

        public Guid CompanyItemId { get; set; }
    }
}