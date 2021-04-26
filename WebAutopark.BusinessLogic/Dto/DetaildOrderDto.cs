using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.Dto
{
    public class DetaildOrderDto
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }

        public VehicleDto Vehicle { get; set; }
        public List<DetaildOrderPartDto> Parts { get; set; }
    }
}
