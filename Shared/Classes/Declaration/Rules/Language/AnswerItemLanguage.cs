using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language
{
    [Serializable]
    public class AnswerItemLanguage
    {
        public Guid Id { get; set; }

        public Guid AnswerItemId { get; set; }

        public Guid LanguageItemId { get; set; }

        public string Question { get; set; }

        public string BoolTrueText { get; set; }

        public string BoolFalseText { get; set; }

        public AnswerItem AnswerItem { get; set; }

        public LanguageItem LanguageItem { get; set; }
    }
}