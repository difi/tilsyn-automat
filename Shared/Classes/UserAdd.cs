﻿using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class UserAddItem
    {
        public UserItem UserItem { get; set; }

        public List<RoleItem> RoleList { get; set; }
    }
}