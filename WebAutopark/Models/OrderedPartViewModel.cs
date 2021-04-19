using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderedPartViewModel
    {
        [Required]
        public int PartID { get; set; }
        [Required]
        public string PartName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PartCount { get; set; }
    }
}
