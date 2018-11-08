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
        [Required(ErrorMessage = "Name field is required!")]
        [AutoComplete("name")]
        public String Name { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "The Social Security Number field is required!")]
        [AutoComplete("off")]
        public String SocialSecurityNumber { get; set; }

        [AutoComplete("email ")]
        public String Email { get; set; }

        [AutoComplete("tel-country-code")]
        public String CountryCode { get; set; }

        [AutoComplete("tel")]
        public String Phone { get; set; }

        [AutoComplete("organization-title")]
        public String Title { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastOnline { get; set; }

        public ICollection<UserRole> RoleList { get; set; }

        public ICollection<UserCompany> CompanyList { get; set; }
    }
}