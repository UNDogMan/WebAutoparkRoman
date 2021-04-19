using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class PartViewModel
    {
        public int ID { get; set; }
        [Required]
        public string PartName { get; set; }
    }
}
