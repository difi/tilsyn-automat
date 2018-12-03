using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationSave
    {
        public Guid Id { get; set; }

        public List<OutcomeData> OutcomeDataList { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }
    }
}