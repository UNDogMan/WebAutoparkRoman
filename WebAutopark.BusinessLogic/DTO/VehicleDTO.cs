using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.DTO
{
    public class VehicleDTO
    {
        public int ID { get; set; }
        public int VehicleTypeID { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Maileage { get; set; }
        public int Color { get; set; }
        public float TankCapacity { get; set; }
        public float Consumption { get; set; }
    }
}
