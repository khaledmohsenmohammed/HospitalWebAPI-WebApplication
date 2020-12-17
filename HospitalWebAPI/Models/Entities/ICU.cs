using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Models.Entities
{
    public class ICU
    {

        [Key]
        public int id { get; set; }
        public int numnerOfDevaises { get; set; }
        public int numberOfBed { get; set; }
        public Hospital hospitalId { get; set; }

    }
}
