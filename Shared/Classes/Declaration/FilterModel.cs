using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class FilterModel
    {
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        public int Status1 { get; set; }

        public int Status2 { get; set; }

        public int Succeeded { get; set; }
    }
}
