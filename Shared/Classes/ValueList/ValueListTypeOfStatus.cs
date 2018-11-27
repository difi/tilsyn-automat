using System;

namespace Difi.Sjalvdeklaration.Shared.Classes.ValueList
{
    [Serializable]
    public class ValueListTypeOfStatus : ValueList
    {
        public String TextAdmin { get; set; }

        public String TextCompany { get; set; }
    }
}