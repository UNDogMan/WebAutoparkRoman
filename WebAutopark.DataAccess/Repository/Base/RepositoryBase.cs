using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repository.Base
{
    public abstract class RepositoryBase : IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection connection;

        protected RepositoryBase(IConnectionProvider connectionProvider)
        {
            connection = connectionProvider.GetConnection();
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
