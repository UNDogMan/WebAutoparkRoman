using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.DTO
{
    public class VehicleTypeDTO
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public float TaxCoefficient { get; set; }
    }
}
