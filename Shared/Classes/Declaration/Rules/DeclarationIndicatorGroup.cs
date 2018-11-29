using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class DeclarationIndicatorGroup
    {
        public Guid DeclarationItemId { get; set; }

        public DeclarationItem DeclarationItem { get; set; }

        public Guid IndicatorItemId { get; set; }

        public IndicatorItem IndicatorItem { get; set; }

        public Guid TestGroupItemId { get; set; }

        public TestGroupItem TestGroupItem { get; set; }

        public Int32 IndicatorInTestGroupOrder { get; set; }

        public Int32 TestGroupOrder { get; set; }
    }
}