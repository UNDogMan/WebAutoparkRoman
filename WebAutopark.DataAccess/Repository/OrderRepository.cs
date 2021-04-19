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
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public Task ClearOrder(int id)
        {
            return connection.ExecuteAsync("delete OrdersParts where OrderID = @ID", new { ID = id });
        }

        public Task Create(Order item)
        {
            return connection.ExecuteAsync("insert into Orders values(@VehicleID)", item);
        }

        public Task<int> CreateWithID(Order item)
        {
            
            return connection.QueryFirstAsync<int>("insert into Orders output INSERTED.ID values(@VehicleID)", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete Orders where ID = @ID", new { ID = id });
        }

        public Task<Order> Get(int id)
        {
            return connection.QueryFirstAsync<Order>("select * from Orders where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            return connection.QueryAsync<Order>("select * from Orders");
        }

        public Task Update(Order item)
        {
            return connection.ExecuteAsync("update Orders set VehicleID = @VehicleID where ID = @ID", item);
        }
    }
}
