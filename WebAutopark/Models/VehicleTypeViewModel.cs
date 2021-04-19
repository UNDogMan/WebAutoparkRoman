using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class VehicleTypeViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Type Name can not be empty")]
        public string TypeName { get; set; }
        [Range(float.Epsilon, float.MaxValue, ErrorMessage = "Tax Coefficient must be positive number")]
        public float TaxCoefficient { get; set; }
    }
}
