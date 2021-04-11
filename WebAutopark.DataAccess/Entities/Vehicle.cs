using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Entities
{
    public class Vehicle
    {
        public int ID { get; set; }
        public int VehicleTypeID { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Maileage { get; set; }
        public Color Color { get; set; }
        public float TankCapacity { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
