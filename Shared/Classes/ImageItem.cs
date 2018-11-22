using System;
using System.ComponentModel.DataAnnotations;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    [Serializable]
    public class ImageItem
    {
        [Key]
        public Guid Id { get; set; }

        public String Blob { get; set; }

        public String Uuid { get; set; }

        public String Name { get; set; }

        public String Container { get; set; }
    }
}