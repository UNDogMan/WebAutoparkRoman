using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        [Required]
        public string VehicleModel { get; set; }
    }
}
