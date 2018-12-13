using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class TestGroupItem
    {
        public Guid Id { get; set; }

        public Int32 Order { get; set; }

        public ICollection<IndicatorTestGroup> IndicatorList { get; set; }

        [NotMapped]
        public TestGroupItemLanguage Language { get; set; }

        [NotMapped] public bool AllDone { get; set; }
    }
}