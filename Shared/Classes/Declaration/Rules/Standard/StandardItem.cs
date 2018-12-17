using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard
{
    [Serializable]
    public class StandardItem
    {
        public Guid Id { get; set; }

        public String Standard { get; set; }

        public String Name { get; set; }

        public List<RuleItem> RuleList { get; set; }
    }
}