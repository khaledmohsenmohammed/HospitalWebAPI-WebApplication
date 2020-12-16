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
        public string FullName { get; set; }
        [Required]
        public int AgeOfPatient { get; set; }
        [Required]
        public long NationalId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string JobOfPatient { get; set; }
        [Required]
        public int TicketNumber { get; set; }
        [Required]
        public Boolean RespiratorDeviceStateb { get; set; }
        [Required]
        public string MedicalReport { get; set; }
        [Required]
        public DateTime DateTimeOfEntering { get; set; }
        [Required]
        public DateTime DateTimeOfCheckout { get; set; } 
        [Required]
        public Guid HospitalId { get; set; }
    }
}
