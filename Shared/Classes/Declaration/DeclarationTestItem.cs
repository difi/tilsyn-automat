using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationTestItem
    {
        public Guid Id { get; set; }

        public Guid DeclarationItemId { get; set; }

        [Display(Name = "TypeOfMachine")]
        public ValueListTypeOfMachine TypeOfMachine { get; set; }

        [Display(Name = "TypeOfTest")]
        public ValueListTypeOfTest TypeOfTest { get; set; }

        [Display(Name = "SupplierAndVersion")]
        public ValueListTypeOfSupplierAndVersion SupplierAndVersion { get; set; }

        public String SupplierAndVersionOther { get; set; }

        public String DescriptionInText { get; set; }

        public String CaseNumber { get; set; }

        public ValueListFinishedStatus FinishedStatus { get; set; }

        public ImageItem Image1 { get; set; }

        public ImageItem Image2 { get; set; }

        public DeclarationItem DeclarationItem { get; set; }

        public List<OutcomeData> OutcomeDataList { get; set; }
    }
}