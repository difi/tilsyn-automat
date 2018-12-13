using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Difi.Sjalvdeklaration.Shared.Attributes;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    [Serializable]
    public class DeclarationTestItem
    {
        public Guid Id { get; set; }

        public Guid DeclarationItemId { get; set; }

        public int StatusCount { get; set; }

        [Display(Name = "Purpose of test")]
        public int PurposeOfTestId { get; set; }

        [ExcelExport]
        [Display(Name = "Has a machine")]
        public bool HaveMachine { get; set; }

        [ExcelExport]
        [Display(Name = "Type of machine")]
        public ValueListTypeOfMachine TypeOfMachine { get; set; }

        [ExcelExport]
        [Display(Name = "Type of test")]
        public ValueListTypeOfTest TypeOfTest { get; set; }

        [ExcelExport]
        [Display(Name = "Purpose of test")]
        public ValueListPurposeOfTest PurposeOfTest { get; set; }

        [ExcelExport]
        public ValueListTypeOfSupplierAndVersion SupplierAndVersion { get; set; }

        [ForeignKey("ValueListTypeOfSupplierAndVersion")]
        [Display(Name = "Choose from the list which manufacturer and model payment terminal you should check", Description = "Difi needs to know which payment terminal you check and submit information about.")]
        public int? SupplierAndVersionId { get; set; }

        [ExcelExport]
        [Display(Name = "Manufacturer and name of automat")]
        public string SupplierAndVersionOther { get; set; }

        [ExcelExport]
        [Display(Name = "Describe which payment terminal you choose to control", Description = "Here you can, for example, type where the payment terminal is located. <br /> Examples are cash register 1, closest to the the entrance / exit, to the left of the the entrance / exit.")]
        public string DescriptionInText { get; set; }

        [ExcelExport]
        [Display(Name = "Take a survey of the payment terminal to register information about. The image will show where the payment terminal is located", Description = "The image should show where the payment terminal is located. The image should show the entire payment terminal and the area in front of the terminal.")]
        public ImageItem Image1 { get; set; }

        public Guid? Image1Id { get; set; }

        [ExcelExport]
        [Display(Name = "Take a close-up of the payment terminal you are going to register information about")]
        public ImageItem Image2 { get; set; }

        public Guid? Image2Id { get; set; }

        [ExcelExport]
        [Display(Name = "Deviation or Notice")]
        public ValueListFinishedStatus FinishedStatus { get; set; }

        [ForeignKey("ValueListFinishedStatus")]
        public int? FinishedStatusId { get; set; }

        public DeclarationItem DeclarationItem { get; set; }

        public List<OutcomeData> OutcomeDataList { get; set; }
    }
}