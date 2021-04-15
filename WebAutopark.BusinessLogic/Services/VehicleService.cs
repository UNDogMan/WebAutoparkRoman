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
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> vehicleRepository;
        private readonly IRepository<VehicleType> vehicleTypeRepository;
        private readonly IMapper mapper;

        public VehicleService(
            IRepository<Vehicle> vehicleRepository, 
            IRepository<VehicleType> vehicleTypeRepository, 
            IMapper mapper)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleTypeRepository = vehicleTypeRepository;
            this.mapper = mapper;
        }

        public Task Create(VehicleDto item)
        {
            return vehicleRepository.Create(mapper.Map<Vehicle>(item));
        }

        public Task Delete(int id)
        {
            return vehicleRepository.Delete(id);
        }

        public async Task<VehicleDto> Get(int id)
        {
            var entity = await vehicleRepository.Get(id);
            return mapper.Map<VehicleDto>(entity);
        }

        public async Task<IEnumerable<VehicleDto>> GetAll()
        {
            var entity = await vehicleRepository.GetAll();
            return mapper.Map<IEnumerable<VehicleDto>>(entity);
        }
        public Task Update(VehicleDto item)
        {
            return vehicleRepository.Update(mapper.Map<Vehicle>(item));
        }

        public async Task<float> GetTaxPerMount(VehicleDto vehicle)
        {
            const float WeightCoefficient = 0.0013f;
            const int BaseTax = 30;
            const int MinTax = 5;
            var type = await vehicleTypeRepository.Get(vehicle.VehicleTypeID);
            return vehicle.Weight * WeightCoefficient + type.TaxCoefficient * BaseTax + MinTax;
        }

        public async Task<float> GetMaxmileage(VehicleDto vehicle)
        {
            return vehicle.TankCapacity / vehicle.Consumption * 100;
        }
    }
}
