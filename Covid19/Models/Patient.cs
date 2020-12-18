using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    [Table("Patient", Schema = "dbo")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("اسم المستشفى")]
        public int HospitalId { get; set; }
        public Hospital hospital { get; set; }
        [Required]
        [StringLength(250)]
        [DisplayName("اسم المريض")]
        public string PName { get; set; }
       
        [DisplayName("الرقم القومى")]
        [MaxLength(14)]
        public int NationalId { get; set; }
        [DisplayName("السن")]
        public int Age { get; set; }
        [StringLength(150)]
        [DisplayName("الوظيفة")]
        public string Job { get; set; }
        [StringLength(350)]
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("رقم التذكرة")]
        public int TicketNumber { get; set; }
        [Required]
        [DisplayName("تاريخ الدخول")]
        public DateTime EnterDate { get; set; }
        [DisplayName("التقرير الطبي")]
        public string Report { get; set; }
        [DisplayName("الحالة")]
        public int StatusID { get; set; }
        public ExitStatus exitStatus { get; set; }

        [DisplayName("تاريخ الخروج")]
        public DateTime ExitDate { get; set; }
    }
}
