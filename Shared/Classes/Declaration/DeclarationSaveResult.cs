using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationSaveResult
    {
        public int StausCount { get; set; }

        public bool Step1Done { get; set; }

        public List<OutcomeData> OutcomeData { get; set; }
    }
}