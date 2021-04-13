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
    public class VehicleService : IVehicleService
    {
        private const float WeightCoefficient = 0.0013f;
        private const int BaseTax = 30;
        private const int MinTax = 5;
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

        public Task Create(VehicleDTO item)
        {
            return vehicleRepository.Create(mapper.Map<Vehicle>(item));
        }

        public Task Delete(int id)
        {
            return vehicleRepository.Delete(id);
        }

        public async Task<VehicleDTO> Get(int id)
        {
            var entity = await vehicleRepository.Get(id);
            return mapper.Map<VehicleDTO>(entity);
        }

        public async Task<IEnumerable<VehicleDTO>> GetAll()
        {
            var entity = await vehicleRepository.GetAll();
            return mapper.Map<IEnumerable<VehicleDTO>>(entity);
        }
        public Task Update(VehicleDTO item)
        {
            return vehicleRepository.Update(mapper.Map<Vehicle>(item));
        }

        public async Task<float> GetMaxmileage(VehicleDTO vehicle)
        {
            var type = await vehicleTypeRepository.Get(vehicle.VehicleTypeID);
            return vehicle.Weight * WeightCoefficient + type.TaxCoefficient * BaseTax + MinTax;
        }

        public async Task<float> GetTaxPerMount(VehicleDTO vehicle)
        {
            return vehicle.TankCapacity / vehicle.Consumption * 100;
        }
    }
}
