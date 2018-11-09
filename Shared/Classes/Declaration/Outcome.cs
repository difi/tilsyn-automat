using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class OutcomeItem
    {
        public Guid Id { get; set; }

        public Guid DeclarationItemId { get; set; }

        public Int32 IndicatorId { get; set; }

        public String DescriptionOutcome { get; set; }

        public String OutcomeType { get; set; }
    }
}