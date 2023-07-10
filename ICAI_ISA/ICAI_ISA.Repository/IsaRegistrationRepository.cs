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

        public async Task<MemberRegistration> GetMemberRegistrationDetails(string membershipNo, string isaRegistrationNo)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();

                query = "SelectInforfromvipisa";
                parameters.Add("membershipno", membershipNo);
                parameters.Add("isadob", isaRegistrationNo);

                var result = await connection.QueryAsync<MemberRegistration>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result.FirstOrDefault();
            }
        }

        public async Task<MemberRegistration> AddMemberRegistrationDetails(MemberRegistration memberRegistration)
        {
            using (var connection = context.CreateConnection())
            {
                var query = string.Empty;
                DynamicParameters parameters = new DynamicParameters();

                query = "isareg_insert";

                parameters.Add("@mem_no", memberRegistration.MemberNo);
                parameters.Add("@isaregno", memberRegistration.IsaRegistrationNo);
                parameters.Add("@name", memberRegistration.MemberName);
                parameters.Add("@fname", memberRegistration.FatherName);
                parameters.Add("@dob", memberRegistration.MemberDob);
                parameters.Add("@sex", memberRegistration.Gender);
                parameters.Add("@prof_city", memberRegistration.ProffesionalCity);
                parameters.Add("@zone", memberRegistration.Zone);
                parameters.Add("@centreno", memberRegistration.CentreNo);
                parameters.Add("@centre", memberRegistration.CentreName);
                parameters.Add("@centstate", memberRegistration.CentreState);
                parameters.Add("@certyear", memberRegistration.Certificateyear);
                parameters.Add("@certmonth", memberRegistration.CertificateMonth);
                parameters.Add("@syllabus", memberRegistration.Syllabus);
                parameters.Add("@pconfsyl", memberRegistration.ConfirmSyllabus);
                parameters.Add("@ppin", memberRegistration.PersonalPin);
                parameters.Add("@add1", memberRegistration.AddressLine1);
                parameters.Add("@add2", memberRegistration.AddressLine2);
                parameters.Add("@add3", memberRegistration.AddressLine3);
                parameters.Add("@add4", memberRegistration.AddressLine4);
                parameters.Add("@city", memberRegistration.City);                
                parameters.Add("@state", memberRegistration.State);
                parameters.Add("@pin", memberRegistration.Pincode);
                parameters.Add("@email", memberRegistration.Email);
                parameters.Add("@mobile", memberRegistration.Mobile);
                parameters.Add("@phone", memberRegistration.Phone);

                parameters.Add("@reg_date", DateTime.Now.ToString("dd/MM/yyyy"));
                parameters.Add("@flg_reg", "Y");

                parameters.Add("@flg_provisional", memberRegistration.ProvisionalFlag);

                parameters.Add("@flgimg", "N");
                parameters.Add("@flgpmt", "N");

                parameters.Add("@exmses", memberRegistration.ExamSession);

                parameters.Add("@optout", memberRegistration.OptOutStatus);

                parameters.Add("@returnid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("outres", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);

                var result = await connection.QueryAsync<MemberRegistration>(query, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                var returnIdentutyValue = parameters.Get<Int32>("returnid");
                var insertStatus = parameters.Get<string>("outres");

                return result.FirstOrDefault();
            }
        }
    }
}
