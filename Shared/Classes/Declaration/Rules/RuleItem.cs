using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class RuleItem
    {
        public Guid Id { get; set; }

        public Guid RequirementItemId { get; set; }

        public Guid ChapterItemId { get; set; }

        public Guid StandardItemId { get; set; }

        public int Order { get; set; }

        public String Instruction { get; set; }

        public String Illustration { get; set; }

        public String HelpText { get; set; }

        public String ToolsNeed { get; set; }

        public ICollection<AnswerItem> AnswerList { get; set; }

        public ChapterItem Chapter { get; set; }

        public StandardItem Standard { get; set; }

        public RequirementItem Requirement { get; set; }
    }
}