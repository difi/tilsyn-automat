using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationItem
    {
        public Guid Id { get; set; }

        public Guid CompanyItemId { get; set; }

        public Guid UserItemId { get; set; }

        [Required]
        public String Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        public DateTime SentInDate { get; set; }

        public DeclarationStatus Status { get; set; }

        public CompanyItem Company { get; set; }

        public UserItem User { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }

        public List<DeclarationTestGroup> TestGroupList { get; set; }
    }
}