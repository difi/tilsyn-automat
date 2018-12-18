using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class AddLinkToCompanyModel
    {
        [Required(ErrorMessage = "The organization number of your business is required")]
        [Display(Name = "Organization number of your business")]
        [RegularExpression("\\d{9}", ErrorMessage = "Organization number must have nine numbers")]
        public string CorporateIdentityNumber { get; set; }

        [Required(ErrorMessage = "Four-digit code is required")]
        [RegularExpression("\\d{4}", ErrorMessage = "Four-digit code must have four numbers")]
        [Display(Name = "Four-digit code")]
        public string Code { get; set; }
    }
}