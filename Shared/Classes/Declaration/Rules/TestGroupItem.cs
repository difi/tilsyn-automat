using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class TestGroupItem
    {
        public Guid Id { get; set; }

        public Int32 Order { get; set; }

        public ICollection<IndicatorTestGroup> IndicatorList { get; set; }

        [NotMapped]
        public TestGroupItemLanguage Language { get; set; }
    }

    public class TestGroupItemLanguage
    {
        public Guid Id { get; set; }

        public Guid TestGroupItemId { get; set; }

        public Guid LanguageItemId { get; set; }

        public string Name { get; set; }

        public TestGroupItem TestGroupItem { get; set; }

        public LanguageItem LanguageItem { get; set; }

    }
}