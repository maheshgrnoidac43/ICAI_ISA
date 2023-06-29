using ICAI_ISA.Model;
using ICAI_ISA.Model.Dto;

namespace ICAI_ISA.Services.Interfaces
{
    public interface IInfoService
    {
        Task<IEnumerable<ExamCenter>> GetExamCenterList();

        Task<ExamSessionDto> GetCurrentExamSessionDetails();
    }
}
