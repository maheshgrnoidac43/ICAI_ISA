using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Model
{
    public class ExamCenter
    {
        [Display(Name = "Center No")]
        public string CenterNo { get; set; }

        [Display(Name = "Center Name")]
        public string CenterName { get; set; }

        [Display(Name = "Center State")]
        public string CenterState { get; set; }

        [Display(Name = "Center Zone")]
        public string? CenterZone { get; set; }
    }
}
