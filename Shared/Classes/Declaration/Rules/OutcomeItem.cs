using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class OutcomeItem
    {
        public Guid Id { get; set; }

        public Int32 IndicatorId { get; set; }

        public String Description { get; set; }

        public String Type { get; set; }

        public RequirementItem Requirement { get; set; }
    }
}