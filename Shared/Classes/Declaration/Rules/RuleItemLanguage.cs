using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class RuleItemLanguage
    {
        public Guid Id { get; set; }

        public Guid RuleItemId { get; set; }

        public Guid LanguageItemId { get; set; }

        public string HelpText { get; set; }

        public RuleItem RuleItem { get; set; }

        public LanguageItem LanguageItem { get; set; }
    }
}