using System;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data
{
    public class AnswerData
    {
        public Guid Id { get; set; }

        public Guid RuleDataId { get; set; }

        public Int32 TypeOfAnswerId { get; set; }

        public Guid AnswerItemId { get; set; }

        public ValueListTypeOfAnswer TypeOfAnswer { get; set; }

        public AnswerItem AnswerItem { get; set; }

        public bool Bool { get; set; }

        public string String { get; set; }

        public int Int { get; set; }

        public ImageItem Image { get; set; }
    }
}