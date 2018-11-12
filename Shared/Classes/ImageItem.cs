using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class ImageItem
    {
        [Key]
        public Guid Id { get; set; }

        public String Path { get; set; }
    }
}