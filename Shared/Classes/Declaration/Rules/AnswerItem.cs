using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
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

        public bool Bool { get; set; }

        public string String { get; set; }

        public int MiniInt { get; set; }

        public int MaxInt { get; set; }

        public RuleItem RuleItem { get; set; }

        public ICollection<AnswerData> AnswerDataList { get; set; }
    }
}