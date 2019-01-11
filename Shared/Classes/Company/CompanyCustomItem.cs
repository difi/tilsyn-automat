using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyCustomItem
    {
        public Guid CompanyItemId { get; set; }

        [Display(Name = "Name of business")]
        [Required(ErrorMessage = "Name is required")]
        public string CustomName { get; set; }

        [Display(Name = "Street name and number")]
        public string CustomBusinessAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        public string CustomBusinessAddressZip { get; set; }

        [Display(Name = "City")]
        public string CustomBusinessAddressCity { get; set; }

        [Display(Name = "Street name and number")]
        public string CustomLocationAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        [RegularExpression("\\d{4}", ErrorMessage = "ZIP Code must have 4 to 5 numbers")]
        public string CustomLocationAddressZip { get; set; }

        [Display(Name = "City")]
        public string CustomLocationAddressCity { get; set; }
    }
}