using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    public class RuleData
    {
        public Guid Id { get; set; }

        public RuleItem Rule { get; set; }

        public RequirementData RequirementData { get; set; }

        public ICollection<AnswerData> AnswerDataList { get; set; }
    }
}