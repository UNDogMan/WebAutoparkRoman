using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        public int ID { get; set; }
        public int VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Weight { get; set; }
        [Required]
        [Range(1800, int.MaxValue)]
        public int ManufactureYear { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Maileage { get; set; }
        [Required]
        public Color Color { get; set; }
        [Required]
        [Range(float.Epsilon, float.MaxValue)]
        public float TankCapacity { get; set; }
        [Required]
        [Range(float.Epsilon, float.MaxValue)]
        public float Consumption { get; set; }
        public float TaxPerMounth { get; set; }
        public float MaxMileage { get; set; }
    }
}
