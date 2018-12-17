using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.Company
{
    [Serializable]
    public class ExcelItemRow
    {
        public CompanyItem CompanyItem { get; set; }

        public ContactPersonItem ContactPersonItem { get; set; }

        public DeclarationItem DeclarationItem { get; set; }
    }
}