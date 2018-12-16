using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Attributes;

namespace Difi.Sjalvdeklaration.Shared.Classes.User
{
    [Serializable]
    public class UserItem
    {
        [Required]
        public Guid Id { get; set; }

        public string Token { get; set; }

        [ExcelExport]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [AutoComplete("name")]
        public string Name { get; set; }

        [ExcelExport]
        [Display(Name = "Social security number")]
        [Required(ErrorMessage = "Social security number is required")]
        [RegularExpression("\\d{9}", ErrorMessage = "Social security number must have nine numbers")]
        [AutoComplete("off")]
        public long? SocialSecurityNumber { get; set; }

        [ExcelExport]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [AutoComplete("email ")]
        public string Email { get; set; }

        [ExcelExport]
        [Display(Name = "Country code")]
        [Required(ErrorMessage = "Country code is required")]
        [AutoComplete("tel-country-code")]
        public string PhoneCountryCode { get; set; }

        [ExcelExport]
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        [AutoComplete("tel")]
        public string Phone { get; set; }

        [ExcelExport]
        [Display(Name = "Position in Difi")]
        [Required(ErrorMessage = "Position in Difi is required")]
        [AutoComplete("organization-title")]
        public string Title { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastOnline { get; set; }

        [Display(Name = "Role list")]
        public ICollection<UserRole> RoleList { get; set; }

        public ICollection<UserCompany> CompanyList { get; set; }
    }
}