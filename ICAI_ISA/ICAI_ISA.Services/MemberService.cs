using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;
using ICAI_ISA.Services.Interfaces;

namespace ICAI_ISA.Services
{
    public class MemberService : IMemberService
    {
        private readonly IIsaRegistrationRepository _isaRegistrationRepository;

        private readonly IPaymentRepository _paymentRepository;

        public MemberService(IIsaRegistrationRepository isaRegistrationRepository, IPaymentRepository paymentRepository)
        {
            _isaRegistrationRepository = isaRegistrationRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentStatusResponse> CheckPaymentStatus(MemberDetail memberDetail)
        {
            return await _isaRegistrationRepository.GetPaymentStatusResponse(memberDetail);
        }

        public async Task<IEnumerable<IsaNoSearchResult>> GetIsaNoDetails(SearchIsaNo searchisanumber)
        {
            return await _isaRegistrationRepository.GetIsaNoDetails(searchisanumber);
        }

        public async Task<MemberRegistration> AddMemberRegistrationDetails(MemberRegistration memberRegistration, SearchOptoutCases searchOptoutCases)
        {
            // Check OptOut Status
            OptoutStatus optoutStatus = await _paymentRepository.GetOptoutCasesResponse(searchOptoutCases);

            memberRegistration.OptOutStatus = optoutStatus.ToString();
            return await _isaRegistrationRepository.AddMemberRegistrationDetails(memberRegistration);
        }

        public async Task<MemberRegistration> GetMemberRegistrationDetails(string membershipNo, string isaRegistrationNo)
        {
            MemberRegistration memberRegistration = await _isaRegistrationRepository.GetMemberRegistrationDetails(membershipNo, isaRegistrationNo);

            // To handle provisional form cases
            if(memberRegistration == null) 
            {
                memberRegistration.ProvisionalFlag = "Y";
            }
            else
            {
                memberRegistration.ProvisionalFlag = "N";
            }
            return memberRegistration;
        }

    }
}
