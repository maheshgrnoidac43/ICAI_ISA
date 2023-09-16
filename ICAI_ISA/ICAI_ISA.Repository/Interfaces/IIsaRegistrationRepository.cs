using ICAI_ISA.Model;

namespace ICAI_ISA.Repository.Interfaces
{
    public interface IIsaRegistrationRepository
    {
        Task<PaymentStatusResponse> GetPaymentStatusResponse(MemberDetail memberDetail);

        Task<IEnumerable<IsaNoSearchResult>> GetIsaNoDetails(SearchIsaNo searchisanumber);
        Task<MemberRegistration> GetMemberRegistrationDetails(string membershipNo, string isaRegistrationNo);
        Task<MemberRegistration> AddMemberRegistrationDetails(MemberRegistration memberRegistration);

        Task<string> GetLoggedInUserDetails(MemberDetail model);

    }   

}