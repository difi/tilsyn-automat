using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class ExcelItemRow
    {
        public CompanyItem CompanyItem { get; set; }

        public ContactPersonItem ContactPersonItem { get; set; }

        public DeclarationItem DeclarationItem { get; set; }
    }
}