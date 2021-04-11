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
    class VehicleTypeServise : IBaseService<VehicleTypeDTO>
    {
        private readonly IRepository<VehicleType> repository;
        private readonly IMapper mapper;

        public VehicleTypeServise(IRepository<VehicleType> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Create(VehicleTypeDTO item)
        {
            return repository.Create(mapper.Map<VehicleType>(item));
        }

        public Task Delete(int id)
        {
            return repository.Delete(id);
        }

        public async Task<VehicleTypeDTO> Get(int id)
        {
            var entity = await repository.Get(id);
            return mapper.Map<VehicleTypeDTO>(entity);
        }

        public async Task<IEnumerable<VehicleTypeDTO>> GetAll()
        {
            var entity = await repository.GetAll();
            return mapper.Map<IEnumerable<VehicleTypeDTO>>(entity);
        }

        public Task Update(VehicleTypeDTO item)
        {
            return repository.Update(mapper.Map<VehicleType>(item));
        }
    }
}
