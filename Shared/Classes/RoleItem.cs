using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class RoleItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public ICollection<UserRole> UserList { get; set; }

        [NotMapped]
        public Boolean Selected { get; set; }
    }
}