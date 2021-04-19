using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutopark.Models
{
    public class DetailVehicleViewModel : VehicleViewModel
    {
        public IEnumerable<int> OrdersID { get; set; } 
    }
}
