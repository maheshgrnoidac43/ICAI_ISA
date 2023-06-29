using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ICAI_ISA.Core
{
    public class SqlDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        //public  async Task<IEnumerable<T>> QueryAsync(string query)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        var result = await this. QueryAsync<T>(query);
        //        return result;
        //    }
        //}

    }
}
