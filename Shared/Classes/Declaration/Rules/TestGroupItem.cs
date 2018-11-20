using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class TestGroupItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public ICollection<IndicatorTestGroup> IndicatorList { get; set; }

        public ICollection<DeclarationTestGroup> DeclarationList { get; set; }
    }
}