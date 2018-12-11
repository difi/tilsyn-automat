using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class AddLinkToCompanyModel
    {
        [Required(ErrorMessage = "The organization number of your business is required")]
        [Display(Name = "Organization number of your business")]
        public string CorporateIdentityNumber { get; set; }

        [Required(ErrorMessage = "Four-digit code is required")]
        [Display(Name = "Four-digit code")]
        public string Code { get; set; }
    }
}