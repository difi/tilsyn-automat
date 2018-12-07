using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class AddLinkToCompanyModel
    {
        [Required]
        [Display(Name = "Organisasjonsnummer til din virksomhet")]
        public string CorporateIdentityNumber { get; set; }

        [Required]
        [Display(Name = "Firesifret kode (NNNN)")]
        public string Code { get; set; }
    }
}