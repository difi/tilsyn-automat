using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class ContactPersonItem
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        //[Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Email - required field")]
        public String Email { get; set; }

        [Display(Name = "PhoneCountryCode")]
        //[Required(ErrorMessage = "PhoneCountryCode - required field")]
        public String PhoneCountryCode { get; set; }

        [Display(Name = "Phone")]
        //[Required(ErrorMessage = "Phone - required field")]
        public String Phone { get; set; }

        public Guid CompanyItemId { get; set; }
    }
}