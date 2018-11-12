using System;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    [Serializable]
    public class OutcomeData
    {
        public Guid Id { get; set; }

        public Guid RequirementDataId { get; set; }

        public Guid OutcomeItemId { get; set; }

        public OutcomeItem Outcome { get; set; }

        public RequirementData RequirementData { get; set; }

        public ValueListTypeOfResult Result { get; set; }

        public String ResultText { get; set; }
    }
}