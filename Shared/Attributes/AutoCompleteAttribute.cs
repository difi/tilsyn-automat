using System;

namespace Difi.Sjalvdeklaration.Shared.Attributes
{
    public class AutoCompleteAttribute : Attribute
    {
        public AutoCompleteAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}