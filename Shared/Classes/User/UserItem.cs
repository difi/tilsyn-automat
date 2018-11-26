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
        [Required(ErrorMessage = "Name - required field")]
        [AutoComplete("name")]
        public String Name { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "Social Security Number - required field")]
        [AutoComplete("off")]
        public String SocialSecurityNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email - required field")]
        [AutoComplete("email ")]
        public String Email { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Country Code - required field")]
        [AutoComplete("tel-country-code")]
        public String CountryCode { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone - required field")]
        [AutoComplete("tel")]
        public String Phone { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title - required field")]
        [AutoComplete("organization-title")]
        public String Title { get; set; }



        [Display(Name = "Created")]
        [Required(ErrorMessage = " Created- required field")]
        public DateTime Created { get; set; }

        [Display(Name = "LastOnline")]
        [Required(ErrorMessage = "LastOnline - required field")]
        public DateTime LastOnline { get; set; }

        [Display(Name = "RoleList")]
        [Required(ErrorMessage = "RoleList - required field")]
        public ICollection<UserRole> RoleList { get; set; }

        [Display(Name = "CompanyList")]
        [Required(ErrorMessage = "CompanyList - required field")]
        public ICollection<UserCompany> CompanyList { get; set; }
    }
}