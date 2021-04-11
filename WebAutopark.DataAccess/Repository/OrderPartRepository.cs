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
    public class OrderPartRepository : RepositoryBase, IRepository<OrderPart>
    {
        public OrderPartRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public Task Create(OrderPart item)
        {
            return connection.ExecuteAsync("insert into OrdersParts values(@PartID, @OrderID, @PartCount); ", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete OrdersParts where ID = @ID", new { ID = id });
        }

        public Task<OrderPart> Get(int id)
        {
            return connection.QueryFirstAsync<OrderPart>("select * from OrdersParts where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<OrderPart>> GetAll()
        {
            return connection.QueryAsync<OrderPart>("select * from OrdersParts");
        }

        public Task Update(OrderPart item)
        {
            return connection.ExecuteAsync("update OrdersParts set PartID = @PartID, OrderID = @OrderID where ID = @ID", item);
        }
    }
}
