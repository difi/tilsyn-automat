using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard
{
    [Serializable]
    public class ChapterItem
    {
        public Guid Id { get; set; }

        public Guid StandardItemId { get; set; }

        public StandardItem Standard { get; set; }

        public String ChapterNumber { get; set; }

        public String ChapterHeading { get; set; }

        public List<RuleItem> RuleList { get; set; }
    }
}