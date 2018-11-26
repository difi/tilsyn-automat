using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.Shared.Classes.ValueList
{
    [Serializable]
    public class ValueListTypeOfResult : ValueList
    {
        [JsonIgnore]
        public List<RuleData> RuleDataList { get; set; }

        [JsonIgnore]
        public List<OutcomeData> OutcomeDataList { get; set; }

        [JsonIgnore]
        public List<AnswerData> AnswerDataList { get; set; }
    }
}