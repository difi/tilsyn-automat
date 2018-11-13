using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    [Serializable]
    public class RequirementData
    {
        public Guid Id { get; set; }

        public OutcomeData OutcomeData { get; set; }

        public RequirementItem Requirement { get; set; }

        public ICollection<RuleData> RuleDataList { get; set; }
    }
}