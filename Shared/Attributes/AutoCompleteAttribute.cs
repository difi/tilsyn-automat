using System;

namespace Difi.Sjalvdeklaration.Shared.Attributes
{
    public class AutoCompleteAttribute : Attribute
    {
        public AutoCompleteAttribute(string value)
        {
            Value = value;
        }

        public String Value { get; set; }
    }
}