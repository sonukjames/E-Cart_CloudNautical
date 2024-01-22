using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Infrastructure
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configration;
        private readonly string _sqlConnectionString;
        public DapperDbContext(IConfiguration configration)
        {
            _configration = configration;
            _sqlConnectionString = _configration.GetConnectionString("SqlConnection");  
        }
        public IDbConnection CreateConnection()
        => new SqlConnection(_sqlConnectionString);
    }
}
