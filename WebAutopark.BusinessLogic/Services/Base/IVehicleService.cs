using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IVehicleService : IBaseService<VehicleDto>
    {
        Task<float> GetTaxPerMount(VehicleDto vehicle);
        Task<float> GetMaxmileage(VehicleDto vehicle);
    }
}
