using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationSave
    {
        public Guid Id { get; set; }

        public DeclarationTestItem DeclarationTestItem { get; set; }
    }
}