using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class StandardChapterItem
    {
        public Guid Id { get; set; }

        public String Standard { get; set; }

        public String ChapterNumber { get; set; }

        public String ChapterHeading { get; set; }

        public String RequirementsInSupervisor { get; set; }
    }
}