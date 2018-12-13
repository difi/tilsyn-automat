using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language
{
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