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

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            this.repository = repository;
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

        public Task<int> CreateWithID(OrderDto item)
        {
            return repository.CreateWithID(mapper.Map<Order>(item));
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

        public Task Update(OrderDto item)
        {
            return repository.Update(mapper.Map<Order>(item));
        }
    }
}
