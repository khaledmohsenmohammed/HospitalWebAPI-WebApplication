using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Models.Entities
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        public long NationalId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public int TicketNumber { get; set; }
        [Required]
        public Boolean RespiratorDeviceStateb { get; set; }
        [Required]
        public string MedicalReport { get; set; }
        [Required]
        public string DateOfEntering { get; set; }
        [Required]
        public string TimeOfEntering { get; set; }
        [Required]
        public Guid HospitalId { get; set; }
        public Hospital Category { get; set; }
    }
}
