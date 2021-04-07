using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities;
using WebAutopark.DataAccess.Repository.Base;

namespace WebAutopark.DataAccess.Repository
{
    public class PartRepository : RepositoryConnection, IRepository<Part>
    {
        public PartRepository(string connectionString) : base(connectionString)
        {
        }

        public Task Create(Part item)
        {
            return connection.ExecuteAsync("insert into Parts values(@PartName)", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete Parts where ID = @ID", new { ID = id });
        }

        public Task<Part> Get(int id)
        {
            return connection.QueryFirstAsync<Part>("select * from Parts where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<Part>> GetAll()
        {
            return connection.QueryAsync<Part>("select * from Parts");
        }

        public Task Update(Part item)
        {
            return connection.ExecuteAsync("update Parts set PartName = @PartName where ID = @ID", item);
        }
    }
}
