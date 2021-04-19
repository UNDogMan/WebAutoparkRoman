using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IOrderService : IBaseService<OrderDto>
    {
        Task ClearOrder(int id);
        Task<int> CreateWithID(OrderDto item);
    }
}
