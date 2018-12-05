using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    [Serializable]
    public class OutcomeData
    {
        public Guid Id { get; set; }

        public Guid IndicatorItemId { get; set; }

        public Guid DeclarationTestItemId { get; set; }

        [ForeignKey("ValueListTypeOfResult")]
        public int ResultId { get; set; }

        public ValueListTypeOfResult Result { get; set; }

        public bool AllDone { get; set; }

        public string ResultText { get; set; }

        public IndicatorItem Indicator { get; set; }

        public ICollection<RuleData> RuleDataList { get; set; }
    }
}