using System;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class RequirementUserPrerequisite
    {
        public Guid RequirementItemId { get; set; }

        public RequirementItem RequirementItem { get; set; }

        public Int32 ValueListUserPrerequisiteId { get; set; }

        public ValueListUserPrerequisite ValueListUserPrerequisite { get; set; }
    }
}