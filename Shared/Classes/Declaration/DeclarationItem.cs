using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Attributes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationItem
    {
        public Guid Id { get; set; }

        public Guid CompanyItemId { get; set; }

        [Display(Name = "Case processor")]
        public Guid UserItemId { get; set; }

        [ForeignKey("ValueListTypeOfStatus")]
        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [ExcelExport]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [ExcelExport]
        [Display(Name = "Case number")]
        public string CaseNumber { get; set; }

        [ExcelExport]
        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [ExcelExport]
        [Display(Name = "Deadline date")]
        [Required(ErrorMessage = "Deadline for submission is required")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [ExcelExport]
        [Display(Name = "Sent in date")]
        public DateTime SentInDate { get; set; }

        [ExcelExport]
        [Display(Name = "Status")]
        public ValueListTypeOfStatus Status { get; set; }

        public CompanyItem Company { get; set; }

        public UserItem User { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }

        public List<DeclarationIndicatorGroup> IndicatorList { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}