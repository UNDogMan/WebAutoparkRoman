using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.DTO;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IVehicleService : IBaseService<VehicleDTO>
    {
        float GetTaxPerMount(VehicleDTO vehicle);
        float GetMaxmileage(VehicleDTO vehicle);
    }
}
