using ICAI_ISA.Model.Dto;

namespace ICAI_ISA.Repository.Interfaces
{
    public interface IExamSessionRepository
    {
        Task<ExamSessionDto> GetCurrentExamSessionDetails();
    }
}
