using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;
using ICAI_ISA.Services.Interfaces;

namespace ICAI_ISA.Services
{
    public class MemberService : IMemberService
    {
        private readonly IIsaRegistrationRepository _isaRegistrationRepository;

        public MemberService(IIsaRegistrationRepository isaRegistrationRepository)
        {
            _isaRegistrationRepository = isaRegistrationRepository;
        }
        public async Task<PaymentStatusResponse> CheckPaymentStatus(MemberDetail memberDetail)
        {
            return await _isaRegistrationRepository.GetPaymentStatusResponse(memberDetail);
        }

        public async Task<IsaNoSearchResult> GetIsaNoDetails(SearchIsaNo searchisanumber)
        {
            return await _isaRegistrationRepository.GetIsaNoDetails(searchisanumber);
        }

    }
}
