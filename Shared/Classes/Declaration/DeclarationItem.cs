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

        [Display(Name = "CompanyItemId")]
        [Required(ErrorMessage = "CompanyItemId - required field")]
        public Guid CompanyItemId { get; set; }

        [Display(Name = "UserItemId")]
        [Required(ErrorMessage = "UserItemId - required field")]
        public Guid UserItemId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "CreatedDate")]
        [Required(ErrorMessage = "CreatedDate - required field")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "DeadlineDate")]
        [Required(ErrorMessage = "DeadlineDate - required field")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Display(Name = "SentInDate")]
        [Required(ErrorMessage = "SentInDate - required field")]
        public DateTime SentInDate { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status - required field")]
        public DeclarationStatus Status { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessage = "Company - required field")]
        public CompanyItem Company { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User - required field")]
        public UserItem User { get; set; }

        [Display(Name = "DeclarationTestItem")]
        [Required(ErrorMessage = "DeclarationTestItem - required field")]
        public DeclarationTestItem DeclarationTestItem { get; set; }

        [Display(Name = "IndicatorList")]
        [Required(ErrorMessage = "IndicatorList - required field")]
        public List<DeclarationIndicatorGroup> IndicatorList { get; set; }
    }
}