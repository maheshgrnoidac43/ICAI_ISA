using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;
using ICAI_ISA.Services.Interfaces;

namespace ICAI_ISA.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIsaRegistrationRepository _isaRegistrationRepository;

        public AccountService(IIsaRegistrationRepository isaRegistrationRepository)
        {
            _isaRegistrationRepository = isaRegistrationRepository;
        }

        public async Task<FormStatus> GetLoggedInUserDetails(MemberDetail model)
        {
            string status = await _isaRegistrationRepository.GetLoggedInUserDetails(model);

            FormStatus formStatus = FormStatus.InvalidData;

            switch (status.ToLower())
            {
                case "form submitted":
                    formStatus = FormStatus.FormSubmitted;
                    break;
                case "invalid membership no or isa registration no":
                    formStatus = FormStatus.InvalidData;
                    break;
                case "select data to show on form":
                    formStatus = FormStatus.FormToBeSubmitted;
                    break;
                case "provisional":
                    formStatus = FormStatus.Provisional;
                    break;
            }
            return formStatus;
        }
    }
}
