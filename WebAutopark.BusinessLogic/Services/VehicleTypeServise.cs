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
    class VehicleTypeServise : IBaseService<VehicleTypeDto>
    {
        private readonly IRepository<VehicleType> repository;
        private readonly IMapper mapper;

        public VehicleTypeServise(IRepository<VehicleType> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(VehicleTypeDto item)
        {
            return repository.Create(mapper.Map<VehicleType>(item));
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<VehicleTypeDto> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<VehicleTypeDto>(entity);
        }

        public async Task<IEnumerable<VehicleTypeDto>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<VehicleTypeDto>>(entity);
        }

        public Task Update(VehicleTypeDto item)
        {
            return repository.Update(mapper.Map<VehicleType>(item));
        }
    }
}
