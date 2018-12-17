using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
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
        public AnswerItemLanguage Language { get; set; }

        [NotMapped]
        public string String { get; set; }

        [NotMapped]
        public ImageItem Image { get; set; }
    }
}