using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    [NotMapped]
    public class homestatistics
    {
        public int HospitalId { get; set; }
        public string hospitaname { get; set; }
        public string subtitle { get; set; }
        public string   bedicon { get; set; }
        public double total { get; set; }
        public double countitems { get; set; }
        public double  percentage { get; set; }
        public string classname { get; set; }

    }
}
