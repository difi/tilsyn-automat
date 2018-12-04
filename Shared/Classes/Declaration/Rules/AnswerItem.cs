using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class AnswerItem
    {
        public Guid Id { get; set; }

        public Guid RuleItemId { get; set; }

        public Int32 TypeOfAnswerId { get; set; }

        public ValueListTypeOfAnswer TypeOfAnswer { get; set; }

        public int Order { get; set; }

        public Guid LinkedParentFailedId { get; set; }

        public Guid LinkedParentCorrectId { get; set; }

        public bool AlwaysVisible { get; set; }

        public bool Bool { get; set; }

        public int MinInt { get; set; }

        public int MaxInt { get; set; }

        public RuleItem RuleItem { get; set; }

        public ICollection<AnswerData> AnswerDataList { get; set; }

        [NotMapped]
        public AnswerItemLanguage AnswerItemLanguage { get; set; }

        [NotMapped]
        public string String { get; set; }

        [NotMapped]
        public ImageItem Image { get; set; }
    }

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

    public class LanguageItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

}