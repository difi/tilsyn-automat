using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class ContactPersonItem
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Country code")]
        public String PhoneCountryCode { get; set; }

        [Display(Name = "Phone")]
        public String Phone { get; set; }

        public Guid CompanyItemId { get; set; }
    }
}