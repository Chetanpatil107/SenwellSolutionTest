using Microsoft.Data.SqlClient;
using System.Data;

namespace SenwellSolutionTest.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _conncecionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _conncecionString = _configuration.GetConnectionString("SqlConnection");

        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_conncecionString);
    }
}
