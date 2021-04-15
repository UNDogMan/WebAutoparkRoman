using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class PartService : IBaseService<PartDto>
    {
        private readonly IRepository<Part> repository;
        private readonly IMapper mapper;

        public PartService(IRepository<Part> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(PartDto item)
        {
            return repository.Create(mapper.Map<Part>(item));
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<PartDto> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<PartDto>(entity);
        }

        public async Task<IEnumerable<PartDto>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<PartDto>>(entity);
        }

        public Task Update(PartDto item)
        {
            return repository.Update(mapper.Map<Part>(item));
        }
    }
}
