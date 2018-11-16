using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    public class RuleData
    {
        public Guid Id { get; set; }

        public Guid RuleItemId { get; set; }

        public Int32 ResultId { get; set; }

        public RuleItem Rule { get; set; }

        public ValueListTypeOfResult Result { get; set; }

        public OutcomeData OutcomeData { get; set; }

        public ICollection<AnswerData> AnswerDataList { get; set; }
    }
}