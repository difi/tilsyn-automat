using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class FilterModel
    {
        [Display(Name = "From date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To date")]
        public DateTime ToDate { get; set; }

        public int Status { get; set; }

        public int Succeeded { get; set; }
    }
}
