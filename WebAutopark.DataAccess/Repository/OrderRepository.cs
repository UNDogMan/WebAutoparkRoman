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

        public Task<int> CreateAndReturnID(Order item)
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

        public async Task<IEnumerable<Order>> GetAllWithIncludes()
        {
            string sql = @"select O.ID, VehicleID, " +
                "V.ID VID, VehicleTypeID, ModelName, RegistrationNumber, Weight, ManufactureYear, Maileage, Color, TankCapacity, Consumption, " +
                "P.ID PID, PartName, " +
                "OP.ID OPID, PartID, OrderID, PartCount from Orders O " +
                "inner join OrdersParts OP on O.ID = OP.OrderID " +
                "inner join Parts P on P.ID = OP.PartID " +
                "inner join Vehicles V on V.ID = O.VehicleID; ";
            var orders = await connection.QueryAsync<Order, Vehicle, Part, OrderPart, Order>(sql, 
                (order, vehicle, part, orderPart) =>
            {
                order.Vehicle = vehicle;
                orderPart.Order = order;
                orderPart.Part = part;
                order.Parts = new List<OrderPart>() { orderPart };
                return order;
            }, splitOn: "VID, PID, OPID");

            var result = orders.GroupBy(o => o.ID).Select(g =>
            {
                var groupedOrder = g.First();
                groupedOrder.Parts = g.Select(o => o.Parts.Single()).ToList();
                return groupedOrder;
            });
            return result;
        }

        public async Task<Order> GetWithIncludes(int id)
        {
            string sql = "select O.ID, VehicleID, " +
                "V.ID VID, VehicleTypeID, ModelName, RegistrationNumber, Weight, ManufactureYear, Maileage, Color, TankCapacity, Consumption, " +
                "P.ID PID, PartName, " +
                "OP.ID OPID, PartID, OrderID, PartCount from Orders O " +
                "inner join OrdersParts OP on O.ID = OP.OrderID inner join Parts P on P.ID = OP.PartID " +
                "inner join Vehicles V on V.ID = O.VehicleID " +
                "where O.ID = @ID;";
            var orders = await connection.QueryAsync<Order, Vehicle, Part, OrderPart, Order>(sql, 
                (order, vehicle, part, orderPart) =>
            {
                order.Vehicle = vehicle;
                orderPart.Order = order;
                orderPart.Part = part;
                order.Parts = new List<OrderPart>() { orderPart };
                return order;
            }, new { ID = id }, splitOn: "VID, PID, OPID");

            var result = orders.GroupBy(o => o.ID).Select(g =>
            {
                var groupedOrder = g.First();
                groupedOrder.Parts = g.Select(o => o.Parts.Single()).ToList();
                return groupedOrder;
            });
            return result.First();
        }

        public Task Update(Order item)
        {
            return connection.ExecuteAsync("update Orders set VehicleID = @VehicleID where ID = @ID", item);
        }
    }
}
