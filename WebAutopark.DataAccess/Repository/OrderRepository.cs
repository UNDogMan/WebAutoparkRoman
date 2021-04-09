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
    public class OrderRepository : RepositoryBase, IRepository<Vehicle>
    {
        public OrderRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public Task Create(Vehicle item)
        {
            return connection.ExecuteAsync("insert into Orders values(@VehicleID)", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete Orders where ID = @ID", new { ID = id });
        }

        public Task<Vehicle> Get(int id)
        {
            return connection.QueryFirstAsync<Vehicle>("select * from Orders where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<Vehicle>> GetAll()
        {
            return connection.QueryAsync<Vehicle>("select * from Orders");
        }

        public Task Update(Vehicle item)
        {
            return connection.ExecuteAsync("update Orders set VehicleID = @VehicleID where ID = @ID", item);
        }
    }
}
