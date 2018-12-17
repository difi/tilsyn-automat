using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language
{
    [Serializable]
    public class IndicatorOutcomeItemLanguage
    {
        public Guid Id { get; set; }

        public Guid IndicatorOutcomeItemId { get; set; }

        public Guid LanguageItemId { get; set; }

        public string OutcomeText { get; set; }

        public IndicatorOutcomeItem IndicatorOutcomeItem { get; set; }

        public LanguageItem LanguageItem { get; set; }
    }
}