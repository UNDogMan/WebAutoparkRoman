using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.DTO;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderPartService : IBaseService<OrderPartDTO>
    {
        private readonly IRepository<OrderPart> repository;
        private readonly IMapper mapper;

        public OrderPartService(IRepository<OrderPart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(OrderPartDTO item)
        {
            return repository.Create(mapper.Map<OrderPart>(item));
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<OrderPartDTO> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<OrderPartDTO>(entity);
        }

        public async Task<IEnumerable<OrderPartDTO>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<OrderPartDTO>>(entity);
        }

        public Task Update(OrderPartDTO item)
        {
            return repository.Update(mapper.Map<OrderPart>(item));
        }
    }
}
