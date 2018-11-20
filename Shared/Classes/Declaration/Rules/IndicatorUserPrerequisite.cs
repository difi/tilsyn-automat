using System;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
    public class IndicatorUserPrerequisite
    {
        public Guid IndicatorItemId { get; set; }

        public IndicatorItem IndicatorItem { get; set; }

        public Int32 ValueListUserPrerequisiteId { get; set; }

        public ValueListUserPrerequisite ValueListUserPrerequisite { get; set; }
    }
}