using System;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules
{
    public class DeclarationTestGroup
    {
        public Guid DeclarationItemId { get; set; }

        public DeclarationItem DeclarationItem { get; set; }

        public Guid TestGroupItemId { get; set; }

        public TestGroupItem TestGroupItem { get; set; }

        public Int32 Order { get; set; }
    }
}