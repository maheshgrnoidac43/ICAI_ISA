using Dapper;
using ICAI_ISA.Core;
using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;
using System.Data;

namespace ICAI_ISA.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SqlDbContext context;

        public PaymentRepository(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task<OptoutStatus> GetOptoutCasesResponse(SearchOptoutCases searchOptoutCases)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();

                query = "sp_select_optout_data";
                parameters.Add("mem_no", searchOptoutCases.MemberNo);
                parameters.Add("mem_name", searchOptoutCases.MemberName);

                var result = await connection.ExecuteScalarAsync<OptoutStatus>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

    }
}
