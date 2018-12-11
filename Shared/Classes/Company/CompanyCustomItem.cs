using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyCustomItem
    {
        public Guid CompanyItemId { get; set; }

        [Display(Name = "Name of business")]
        public string CustomName { get; set; }

        [Display(Name = "Street name and number")]
        public string CustomAddressStreet { get; set; }

        [Display(Name = "ZIP code")]
        public string CustomAddressZip { get; set; }

        [Display(Name = "City")]
        public string CustomAddressCity { get; set; }
    }
}