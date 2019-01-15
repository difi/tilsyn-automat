using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.ValueList
{
    [Serializable]
    public class ValueListTypeOfStatus : ValueList
    {
        public String TextCompany { get; set; }

        public String CompanyNb { get; set; }

        public String CompanyNn { get; set; }
    }
}