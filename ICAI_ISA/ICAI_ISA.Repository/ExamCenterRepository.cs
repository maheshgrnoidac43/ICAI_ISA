using Dapper;
using ICAI_ISA.Core;
using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;

namespace ICAI_ISA.Repository
{
    public class ExamCenterRepository : IExamCenterRepository
    {
        private readonly SqlDbContext context;

        public ExamCenterRepository(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ExamCenter>> GetExamCenterList()
        {
            var query = "SELECT CenterNo, CenterName, CenterState, CenterZone FROM ExamCenter order by convert(int,CenterNo),CenterName";

            using (var connection = context.CreateConnection())
            {
                var examCenters = await connection.QueryAsync<ExamCenter>(query).ConfigureAwait(false);
                return examCenters.ToList();
            }
        }
    }
}
