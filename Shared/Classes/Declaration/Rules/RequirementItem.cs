using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
    public class RequirementItem
    {
        public Guid Id { get; set; }

        public Guid IndicatorItemId { get; set; }

        public ICollection<RuleItem> RuleList { get; set; }

        public ICollection<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }

        [NotMapped]
        public RequirementItemLanguage Language { get; set; }
    }
}