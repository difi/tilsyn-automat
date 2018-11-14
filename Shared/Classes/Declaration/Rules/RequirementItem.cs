using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
    public class RequirementItem
    {
        public Guid Id { get; set; }

        public Guid TestGroupItemId { get; set; }

        public int Order { get; set; }

        public String Description { get; set; }

        public Int32 IndicatorId { get; set; }

        public ICollection<RuleItem> RuleList { get; set; }

        public ICollection<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }

        public ICollection<OutcomeData> OutcomeDataList { get; set; }

        public TestGroupItem TestGroup { get; set; }
    }
}