using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.DataAccess.Repository.Base
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task ClearOrder(int id);
        Task<int> CreateWithID(Order item);
    }
}
