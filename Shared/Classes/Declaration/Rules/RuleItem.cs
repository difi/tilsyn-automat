using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class RuleItem
    {
        public Guid Id { get; set; }

        public Guid RequirementItemId { get; set; }

        public Guid StandardChapterItemId { get; set; }

        public int Order { get; set; }

        public String Instruction { get; set; }

        public String Illustration { get; set; }

        public String HelpText { get; set; }

        public String ToolsNeed { get; set; }

        public ICollection<AnswerItem> AnswerList { get; set; }

        public StandardChapterItem StandardChapter { get; set; }

        [Required]
        public RequirementItem Requirement { get; set; }
    }
}