using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
    public class IndicatorItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public DateTime LastChanged { get; set; }

        public ICollection<RuleItem> RuleList { get; set; }

        public ICollection<IndicatorUserPrerequisite> IndicatorUserPrerequisiteList { get; set; }

        public ICollection<IndicatorTestGroup> TestGroupList { get; set; }

        [JsonIgnore]
        public ICollection<OutcomeData> OutcomeDataList { get; set; }

        [JsonIgnore]
        public ICollection<DeclarationIndicatorGroup> DeclarationList { get; set; }

        [NotMapped]
        public OutcomeData OutcomeData { get; set; }
    }
}