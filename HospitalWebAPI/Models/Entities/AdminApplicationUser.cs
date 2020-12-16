using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Models.Entities
{
    public class AdminApplicationUser
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Boolean TypeOfJop { get; set; }  //true = Hospital //false = Moderea
    }
}
