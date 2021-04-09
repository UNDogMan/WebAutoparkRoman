using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebAutopark.DataAccess.Repository.Base
{
    public class ConnectionProvider : IConnectionProvider
    {
        private string connectionString;

        public ConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
