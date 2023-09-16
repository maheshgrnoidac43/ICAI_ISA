using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Model
{
    public class SearchOptoutCases
    {
        [Required(ErrorMessage = "Please enter Membership No!", AllowEmptyStrings = false)]
        public string MemberNo { get; set; }

        [Required(ErrorMessage = "Please enter Member Name!", AllowEmptyStrings = false)]
        public string MemberName { get; set; }
    }
}
