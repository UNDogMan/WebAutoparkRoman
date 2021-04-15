using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderPartService : IBaseService<OrderPartDto>
    {
        private readonly IRepository<OrderPart> repository;
        private readonly IMapper mapper;

        public OrderPartService(IRepository<OrderPart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(OrderPartDto item)
        {
            return repository.Create(mapper.Map<OrderPart>(item));
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<OrderPartDto> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<OrderPartDto>(entity);
        }

        public async Task<IEnumerable<OrderPartDto>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<OrderPartDto>>(entity);
        }

        public Task Update(OrderPartDto item)
        {
            return repository.Update(mapper.Map<OrderPart>(item));
        }
    }
}
