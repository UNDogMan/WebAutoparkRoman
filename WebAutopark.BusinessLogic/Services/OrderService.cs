using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Repository;
using WebAutopark.DataAccess.Entities;
using WebAutopark.BusinessLogic.Extensions;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IRepository<OrderPart> orderPartRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IRepository<OrderPart> orderPartRepository, IMapper mapper)
        {
            this.repository = repository;
            this.orderPartRepository = orderPartRepository;
            this.mapper = mapper;
        }

        public Task ClearOrder(int id)
        {
            return repository.ClearOrder(id);
        }

        public Task Create(OrderDto item)
        {
            return repository.Create(mapper.Map<Order>(item));
        }

        public Task<int> CreateAndReturnID(OrderDto item)
        {
            return repository.CreateAndReturnID(mapper.Map<Order>(item));
        }

        public async Task CreateForParts(int vehicleId, IEnumerable<OrderPartDto> parts)
        {
            int orderId = await this.CreateAndReturnID(new OrderDto { VehicleID = vehicleId });
            parts = parts.Select(x => x.DoAction(x => x.OrderID = orderId));
            foreach(var part in parts)
            {
                await orderPartRepository.Create(mapper.Map<OrderPart>(part));
            }
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<OrderDto> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<OrderDto>(entity);
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<OrderDto>>(entity);
        }

        public async Task<IEnumerable<DetaildOrderDto>> GetAllWithIncludes()
        {
            var entity = await repository.GetAllWithIncludes();
            return mapper.Map<IEnumerable<DetaildOrderDto>>(entity);
        }

        public async Task<DetaildOrderDto> GetWithIncludes(int id)
        {
            var entity = await repository.GetWithIncludes(id);
            return mapper.Map<DetaildOrderDto>(entity);
        }

        public Task Update(OrderDto item)
        {
            return repository.Update(mapper.Map<Order>(item));
        }
    }
}
