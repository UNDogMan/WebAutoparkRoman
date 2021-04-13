using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.DTO;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : IBaseService<OrderDTO>
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(OrderDTO item)
        {
            return repository.Create(mapper.Map<Order>(item)); ;
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<OrderDTO> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<OrderDTO>(entity);
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<OrderDTO>>(entity);
        }

        public Task Update(OrderDTO item)
        {
            return repository.Update(mapper.Map<Order>(item));
        }
    }
}
