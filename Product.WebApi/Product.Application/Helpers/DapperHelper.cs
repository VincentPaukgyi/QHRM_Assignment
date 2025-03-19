using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Product.Application.Helpers
{
    public abstract class DapperHelper
    {
        private readonly string _connectionString;
        public DapperHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
