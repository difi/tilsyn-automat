using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language
{
    [Serializable]
    public class RequirementItemLanguage
    {
        public Guid Id { get; set; }

        public Guid RequirementItemId { get; set; }

        public Guid LanguageItemId { get; set; }

        public string Description { get; set; }

        public RequirementItem RequirementItem { get; set; }

        public LanguageItem LanguageItem { get; set; }
    }
}