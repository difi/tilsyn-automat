using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class DeclarationItem
    {
        public Guid Id { get; set; }

        public Guid CompanyItemId { get; set; }

        public Guid UserItemId { get; set; }

        public String Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DeclarationStatus Status { get; set; }

        public CompanyItem Company { get; set; }

        public UserItem User { get; set; }
    }
}