﻿using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class IndicatorTestGroup
    {
        public Guid IndicatorItemId { get; set; }

        public IndicatorItem IndicatorItem { get; set; }

        public Guid TestGroupItemId { get; set; }

        public TestGroupItem TestGroupItem { get; set; }
    }
}