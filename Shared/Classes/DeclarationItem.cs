using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
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
    }
}