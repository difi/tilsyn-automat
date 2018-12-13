using System;

namespace Difi.Sjalvdeklaration.Shared.Attributes
{
    public class ExcelExportAttribute : Attribute
    {
        public ExcelExportAttribute()
        {
        }

        public ExcelExportAttribute(string extraHeader)
        {
            ExtraHeader = extraHeader;
        }

        public string ExtraHeader { get; set; }
    }
}