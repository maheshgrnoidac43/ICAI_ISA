using ICAI_ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Services.Interfaces
{
    public interface IAccountService
    {
        Task<FormStatus> GetLoggedInUserDetails(MemberDetail model);
        
    }
}
