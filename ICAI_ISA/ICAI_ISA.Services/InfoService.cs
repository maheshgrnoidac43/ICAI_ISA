using ICAI_ISA.Model;
using ICAI_ISA.Model.Dto;
using ICAI_ISA.Repository;
using ICAI_ISA.Repository.Interfaces;
using ICAI_ISA.Services.Interfaces;

namespace ICAI_ISA.Services
{
    public class InfoService : IInfoService
    {
        private readonly IExamCenterRepository _examCenterRepository;

        private readonly IExamSessionRepository _examSessionRepository;

        public InfoService(IExamCenterRepository examCenterRepository, IExamSessionRepository examSessionRepository)
        {
            _examCenterRepository = examCenterRepository;
            _examSessionRepository = examSessionRepository;
        }

        public async Task<IEnumerable<ExamCenter>> GetExamCenterList()
        {
            return await _examCenterRepository.GetExamCenterList();
        }

        public async Task<ExamSessionDto> GetCurrentExamSessionDetails()
        {
            return await _examSessionRepository.GetCurrentExamSessionDetails();
        }
    }
}
