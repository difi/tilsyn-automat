using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Enum;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationItem
    {
        public Guid Id { get; set; }

        public Guid CompanyItemId { get; set; }

        [Display(Name = "UserItemId")]
        public Guid UserItemId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "DeadlineDate")]
        [Required(ErrorMessage = "DeadlineDate - required field")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Display(Name = "SentInDate")]
        public DateTime SentInDate { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status - required field")]
        public DeclarationStatus Status { get; set; }

        public CompanyItem Company { get; set; }

        public UserItem User { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }

        public List<DeclarationIndicatorGroup> IndicatorList { get; set; }
    }
}