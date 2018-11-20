﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    [Serializable]
    public class RequirementItem
    {
        public Guid Id { get; set; }

        public Guid IndicatorItemId { get; set; }

        public int Order { get; set; }

        public String Description { get; set; }

        public ICollection<RuleItem> RuleList { get; set; }

        public ICollection<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }

        public IndicatorItem Indicator { get; set; }

        [NotMapped]
        public OutcomeData OutcomeData { get; set; }

    }
}