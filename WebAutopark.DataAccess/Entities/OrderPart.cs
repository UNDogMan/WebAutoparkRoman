using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Entities
{
    public class OrderPart
    {
        public int ID { get; set; }
        public int PartID { get; set; }
        public int OrderID { get; set; }

        public int PartCount { get; set; }

        public Part Part { get; set; }
        public Order Order { get; set; }
    }
}
