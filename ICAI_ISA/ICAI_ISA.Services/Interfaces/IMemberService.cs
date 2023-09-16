using ICAI_ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Services.Interfaces
{
    public interface IMemberService
    {
        Task<PaymentStatusResponse> CheckPaymentStatus(MemberDetail memberDetail);
        Task<IEnumerable<IsaNoSearchResult>> GetIsaNoDetails(SearchIsaNo searchisanumber);
        Task<MemberRegistration> GetMemberRegistrationDetails(string membershipNo, string isaRegistrationNo);
        Task<MemberRegistration> AddMemberRegistrationDetails(MemberRegistration memberRegistration, SearchOptoutCases searchOptoutCases);
    }
}