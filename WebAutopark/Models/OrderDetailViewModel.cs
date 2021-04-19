using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutopark.Models
{
    public class OrderDetailViewModel
    {
        public int ID { get; set; }
        public string VehicleModel { get; set; }
        public IEnumerable<OrderedPartViewModel> Parts { get; set; }
    }
}
