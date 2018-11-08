using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        public String Path { get; set; }
    }
}