using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationTestItem
    {
        [ForeignKey("DeclarationItem")]
        public Guid Id { get; set; }

        public Int32 TypeOfMachine { get; set; }

        public Int32 TypeOfTest { get; set; }

        public Int32 SupplierAndVersion { get; set; }

        public String SupplierAndVersionOther { get; set; }

        public String DescriptionInText { get; set; }

        public Image Image1 { get; set; }

        public Image Image2 { get; set; }
    }
}