using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationTestItem
    {
        public Guid Id { get; set; }

        public Guid DeclarationItemId { get; set; }

        [Display(Name = "TypeOfMachine")]
        //[Required(ErrorMessage = "TypeOfMachine - required field")]
        public ValueListTypeOfMachine TypeOfMachine { get; set; }

        [Display(Name = "TypeOfTest")]
        //[Required(ErrorMessage = "TypeOfTest - required field")]
        public ValueListTypeOfTest TypeOfTest { get; set; }

        [Display(Name = "SupplierAndVersion")]
        //[Required(ErrorMessage = "SupplierAndVersion - required field")]
        public ValueListTypeOfSupplierAndVersion SupplierAndVersion { get; set; }

        [Display(Name = "SupplierAndVersionOther")]
        //[Required(ErrorMessage = "SupplierAndVersionOther - required field")]
        public String SupplierAndVersionOther { get; set; }

        [Display(Name = "DescriptionInText")]
        //[Required(ErrorMessage = "DescriptionInText - required field")]
        public String DescriptionInText { get; set; }

        [Display(Name = "FinishedStatus")]
        //[Required(ErrorMessage = "FinishedStatus - required field")]
        public ValueListFinishedStatus FinishedStatus { get; set; }

        [Display(Name = "Image1")]
        //[Required(ErrorMessage = "Image1 - required field")]
        public ImageItem Image1 { get; set; }

        [Display(Name = "Image2")]
        //[Required(ErrorMessage = "Image2 - required field")]
        public ImageItem Image2 { get; set; }

        public DeclarationItem DeclarationItem { get; set; }

        public List<OutcomeData> OutcomeDataList { get; set; }
    }
}