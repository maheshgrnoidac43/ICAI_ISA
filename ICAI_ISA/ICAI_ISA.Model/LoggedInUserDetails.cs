using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Model
{
    public class LoggedInUserDetails
    {
        public string UserName { get; set; }

        public string ControlNo { get; set; }

        public string MembershipNo { get; set; }

        public string RegistrationNo { get; set; }

        public bool IsLoggedIn { get; set; }

        public string ErrorMessage { get; set; }
    }
}
