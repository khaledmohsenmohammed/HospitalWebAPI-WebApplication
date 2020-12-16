using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Models.Entities
{
    public class Hospital
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string HospitalName { get; set; }
        public IList<Patient> BookCategories { get; set; }
    }
}
