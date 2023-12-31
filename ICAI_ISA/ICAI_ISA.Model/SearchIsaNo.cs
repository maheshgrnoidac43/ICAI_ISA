﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Model
{
    public class SearchIsaNo
    {
        [Required(ErrorMessage = "Please enter Membership No!", AllowEmptyStrings = false)]
        public string MemberNo { get; set; }

        [Required(ErrorMessage = "Please enter Date of Birth!", AllowEmptyStrings = false)]
        public string Dob { get; set; }
    }
}
