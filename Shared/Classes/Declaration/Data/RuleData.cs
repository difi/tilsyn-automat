using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    public class RuleData
    {
        public Guid Id { get; set; }

        public RuleItem Rule { get; set; }

        public RequirementData RequirementData { get; set; }

        public bool Bool { get; set; }

        public string String { get; set; }

        public int Int { get; set; }

        public ImageItem Image { get; set; }
    }
}