using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class RuleItem
    {
        public Guid Id { get; set; }

        public Guid RequirementItemId { get; set; }

        public Guid IndicatorItemId { get; set; }

        public Guid ChapterItemId { get; set; }

        public Guid StandardItemId { get; set; }

        public int Order { get; set; }

        public ICollection<AnswerItem> AnswerList { get; set; }

        public ChapterItem Chapter { get; set; }

        public StandardItem Standard { get; set; }

        public RequirementItem Requirement { get; set; }

        public IndicatorItem Indicator { get; set; }

        public ICollection<RuleData> RuleDataList { get; set; }

        [NotMapped]
        public RuleItemLanguage Language { get; set; }
    }
}