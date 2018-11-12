using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class RequirementItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public ICollection<RuleItem> RuleList { get; set; }

        public ICollection<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }
    }
}