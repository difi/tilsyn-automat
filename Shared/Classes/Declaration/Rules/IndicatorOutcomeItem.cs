using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class IndicatorOutcomeItem
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string ResultString1 { get; set; }

        public string ResultString2 { get; set; }

        public Guid IndicatorItemId { get; set; }

        public IndicatorItem IndicatorItem { get; set; }

        [NotMapped]
        public IndicatorOutcomeItemLanguage Language { get; set; }
    }
}