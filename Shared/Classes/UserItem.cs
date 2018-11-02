using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class UserItem
    {
        [Required]
        public Guid Id { get; set; }

        public String IdPortenSub { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "The Social Security Number field is required!")]
        public String SocialSecurityNumber { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public String Title { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastOnline { get; set; }

        public ICollection<UserRole> RoleList { get; set; }

        public ICollection<UserCompany> CompanyList { get; set; }
    }
}