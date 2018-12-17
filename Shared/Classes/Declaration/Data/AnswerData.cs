using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    [Serializable]
    public class AnswerData
    {
        public Guid Id { get; set; }

        public Guid RuleDataId { get; set; }

        public Int32 TypeOfAnswerId { get; set; }

        public Guid AnswerItemId { get; set; }

        public Int32 ResultId { get; set; }

        public ValueListTypeOfAnswer TypeOfAnswer { get; set; }

        public AnswerItem AnswerItem { get; set; }

        public Guid? ImageId { get; set; }

        public bool? Bool { get; set; }

        public string String { get; set; }

        public int? Int { get; set; }

        public ImageItem Image { get; set; }

        public ValueListTypeOfResult Result { get; set; }
    }
}