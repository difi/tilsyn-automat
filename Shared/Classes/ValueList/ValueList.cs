using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes.ValueList
{
    [Serializable]
    public class ValueList
    {
        [Key]
        public Int32 Id { get; set; }

        public String Text { get; set; }

        public String Nb { get; set; }

        public String Nn { get; set; }
    }
}