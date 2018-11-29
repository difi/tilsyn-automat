using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
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

        [ForeignKey("ValueListTypeOfStatus")]
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status - required field")]
        public Int32 StatusId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name - required field")]
        public String Name { get; set; }

        [Display(Name = "CaseNumber")]
        //[Required(ErrorMessage = "CaseNumber - required field")]
        public String CaseNumber { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "DeadlineDate")]
        [Required(ErrorMessage = "DeadlineDate - required field")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Display(Name = "SentInDate")]
        public DateTime SentInDate { get; set; }

        public ValueListTypeOfStatus Status { get; set; }

        public CompanyItem Company { get; set; }

        public UserItem User { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }

        public List<DeclarationIndicatorGroup> IndicatorList { get; set; }
    }
}