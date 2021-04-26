using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutopark.Models
{
    public class OrderDetailViewModel
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public IEnumerable<OrderedPartViewModel> Parts { get; set; }
    }
}
