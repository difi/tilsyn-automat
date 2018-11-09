using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationTestItem
    {
        [ForeignKey("DeclarationItem")]
        public Guid Id { get; set; }

        [Display(Name = "TypeOfMachine")]
        public ValueListTypeOfMachine TypeOfMachine { get; set; }

        [Display(Name = "TypeOfTest")]
        public ValueListTypeOfTest TypeOfTest { get; set; }

        [Display(Name = "SupplierAndVersion")]
        public ValueListTypeOfSupplierAndVersion SupplierAndVersion { get; set; }

        public String SupplierAndVersionOther { get; set; }

        public String DescriptionInText { get; set; }

        public Image Image1 { get; set; }

        public Image Image2 { get; set; }
    }
}