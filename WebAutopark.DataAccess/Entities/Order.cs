using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
