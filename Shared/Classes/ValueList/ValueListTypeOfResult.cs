using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.ValueList
{
    [Serializable]
    public class ValueListTypeOfResult : ValueList
    {
        public List<RuleData> RuleDataList { get; set; }

        public List<OutcomeData> OutcomeDataList { get; set; }

        public List<AnswerData> AnswerDataList { get; set; }
    }
}