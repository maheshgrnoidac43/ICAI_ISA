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

        Task<IsaNoSearchResult> GetIsaNoDetails(SearchIsaNo searchisanumber);
    }
}
