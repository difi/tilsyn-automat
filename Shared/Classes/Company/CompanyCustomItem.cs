using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class CompanyCustomItem
    {
        public Guid CompanyItemId { get; set; }

        [Display(Name = "CustomName")]
        //[Required(ErrorMessage = "CustomName - required field")]
        public string CustomName { get; set; }

        [Display(Name = "CustomAddressStreet")]
        //[Required(ErrorMessage = "CustomAddressStreet - required field")]
        public string CustomAddressStreet { get; set; }

        [Display(Name = "CustomAddressZip")]
        //[Required(ErrorMessage = "CustomAddressZip - required field")]
        public string CustomAddressZip { get; set; }

        [Display(Name = "CustomAddressCity")]
        //[Required(ErrorMessage = "CustomAddressCity - required field")]
        public string CustomAddressCity { get; set; }
    }
}