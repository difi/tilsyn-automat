﻿using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class ContactPersonItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public Guid CompanyItemId { get; set; }
    }
}