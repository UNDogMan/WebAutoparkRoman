﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.Dto
{
    public class OrderDto
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public VehicleDto Vehicle { get; set; }
        public List<OrderPartDto> Parts { get; set; }
    }
}
