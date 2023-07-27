using Dapper;
using ICAI_ISA.Core;
using ICAI_ISA.Model;
using ICAI_ISA.Repository.Interfaces;
using System.Data;

namespace ICAI_ISA.Repository
{
    public class IsaRegistrationRepository : IIsaRegistrationRepository
    {
        private readonly SqlDbContext context;

        public IsaRegistrationRepository(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task<PaymentStatusResponse> GetPaymentStatusResponse(MemberDetail memberDetail)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();
                if (memberDetail.MembershipNo != "" && memberDetail.RegistrationNo == "")
                {
                    query = "CheckPaymentStatusWithMembershipNo";
                    parameters.Add("membershipNo", memberDetail.MembershipNo);
                }
                else if (memberDetail.MembershipNo == "" & memberDetail.RegistrationNo != "")
                {
                    query = "CheckPaymentStatusWithIsaRegistrationNo";
                    parameters.Add("isaRegistrationNo", memberDetail.RegistrationNo);
                }
                else if(memberDetail.MembershipNo != "" & memberDetail.RegistrationNo != "")
                {
                    query = "CheckPaymentStatusWithMembershipNoAndIsaRegistrationNo";
                    parameters.Add("membershipNo", memberDetail.MembershipNo);
                    parameters.Add("isaRegistrationNo", memberDetail.RegistrationNo);
                }

                parameters.Add("outres", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
                var result = await connection.QueryAsync<PaymentStatusResponse>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                var paymentStatus = parameters.Get<string>("outres");
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<IsaNoSearchResult>> GetIsaNoDetails(SearchIsaNo searchisanumber)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();
                
                query = "ChkeckIsaRegistrationNoInVipData";
                parameters.Add("membershipno", searchisanumber.MemberNo);
                parameters.Add("isadob", searchisanumber.Dob);                
                
                var result = await connection.QueryAsync<IsaNoSearchResult>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

        public async Task<string> GetLoggedInUserDetails(MemberDetail model)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();

                query = "ValidateIsaMemberAndRegistration";
                parameters.Add("membershipNo", model.MembershipNo);
                parameters.Add("@isaRegNo", model.RegistrationNo);

                parameters.Add("status", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var result = await connection.ExecuteScalarAsync<string>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

    }
}
