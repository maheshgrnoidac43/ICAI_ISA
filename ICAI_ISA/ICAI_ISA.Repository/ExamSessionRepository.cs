using Dapper;
using ICAI_ISA.Core;
using ICAI_ISA.Model;
using ICAI_ISA.Model.Dto;
using ICAI_ISA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAI_ISA.Repository
{
    public class ExamSessionRepository : IExamSessionRepository
    {
        private readonly SqlDbContext context;

        public ExamSessionRepository(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task<ExamSessionDto> GetCurrentExamSessionDetails()
        {
            using (var connection = context.CreateConnection())
            {
                var queryExamSession = "SELECT ExamId, SessionName from ExamSession where IsActive = 'True'";
                var examSession = await connection.QueryAsync<ExamSession>(queryExamSession).ConfigureAwait(false);

                var queryExamSessiondetails  = "SELECT ExamSessionDetailNo, ExamId, SessionKey, SessionValue from ExamSessionDetails where ExamId = " + examSession?.FirstOrDefault()?.ExamId;
                var examSessionDetails = await connection.QueryAsync<ExamSessionDetails>(queryExamSessiondetails).ConfigureAwait(false);

                ExamSessionDto examSessionDto = new ExamSessionDto();
                examSessionDto.CurrentExamSession = examSession?.FirstOrDefault();
                examSessionDto.CurrentExamSessionDetails = examSessionDetails.ToList();

                return examSessionDto;
            }
        }
    }
}
