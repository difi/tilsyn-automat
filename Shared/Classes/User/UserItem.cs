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

        public String Token { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [AutoComplete("name")]
        public String Name { get; set; }

        [Display(Name = "Social security number")]
        [Required(ErrorMessage = "Social security number is required")]
        [AutoComplete("off")]
        public String SocialSecurityNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [AutoComplete("email ")]
        public String Email { get; set; }

        [Display(Name = "Country code")]
        [Required(ErrorMessage = "Country code is required")]
        [AutoComplete("tel-country-code")]
        public String PhoneCountryCode { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        [AutoComplete("tel")]
        public String Phone { get; set; }

        [Display(Name = "Position in Difi")]
        [Required(ErrorMessage = "Position in Difi is required")]
        [AutoComplete("organization-title")]
        public String Title { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastOnline { get; set; }

        [Display(Name = "Role list")]
        public ICollection<UserRole> RoleList { get; set; }

        public ICollection<UserCompany> CompanyList { get; set; }
    }
}