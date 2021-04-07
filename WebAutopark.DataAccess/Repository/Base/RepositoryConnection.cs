using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repository.Base
{
    public abstract class RepositoryConnection : IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection connection;

        protected RepositoryConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            connection?.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return connection.DisposeAsync();
        }
    }
}
