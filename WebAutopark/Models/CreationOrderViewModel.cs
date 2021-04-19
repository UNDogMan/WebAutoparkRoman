using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class CreationOrderViewModel
    {
        public int ID { get; set; }
        [Required]
        public int VehicleID { get; set; }
        public IEnumerable<OrderedPartViewModel> Parts{ get; set; }
    }
}
