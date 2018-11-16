using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    [Serializable]
    public class OutcomeData
    {
        public Guid Id { get; set; }

        public Guid RequirementItemId { get; set; }

        public Guid DeclarationTestItemId { get; set; }

        public ValueListTypeOfResult Result { get; set; }

        public String ResultText { get; set; }

        public RequirementItem Requirement { get; set; }

        public ICollection<RuleData> RuleDataList { get; set; }
    }
}