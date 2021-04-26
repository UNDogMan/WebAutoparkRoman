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
        Task<int> CreateAndReturnID(OrderDto item);
        Task<DetaildOrderDto> GetWithIncludes(int id);
        Task<IEnumerable<DetaildOrderDto>> GetAllWithIncludes();
        Task CreateForParts(int vehicleId, IEnumerable<OrderPartDto> parts);
    }
}
