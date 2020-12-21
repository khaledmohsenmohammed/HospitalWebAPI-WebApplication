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
        
        [DisplayName("اسم المستشفى")]
        public int HospitalId { get; set; }
        [DisplayName("المستشفى")]
        public Hospital hospital { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(250)]
        [DisplayName("اسم المريض")]
        public string PName { get; set; }

        [DisplayName("الرقم القومى")]
        [StringLength(14, MinimumLength = 14,
        ErrorMessage = "الرقم القومى 14 رقم")]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public string NationalId { get; set; }
        [DisplayName("السن")]
        [Range(0, double.MaxValue, ErrorMessage = "ادخل رقم صحيح")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double Age { get; set; } = 0;
        [StringLength(150)]
        [DisplayName("الوظيفة")]
        public string Job { get; set; }
        [StringLength(350)]
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("رقم التذكرة")]
        [Range(0, int.MaxValue, ErrorMessage = "ادخل رقم صحيح")]
        public int TicketNumber { get; set; }
        [Required]
        [DisplayName("تاريخ الدخول")]
        public DateTime EnterDate { get; set; }
        
        [DisplayName("جهاز تنفس")]
        public bool Onvent { get; set; }
        [DisplayName("التقرير الطبي")]
        public string Report { get; set; }
        [DisplayName("الحالة")]
        [Range(0, int.MaxValue, ErrorMessage = "ادخل رقم صحيح")]
        public int StatusID { get; set; } = 0;
        public ExitStatus exitStatus { get; set; }

        [DisplayName("تاريخ الخروج")]
        public DateTime ExitDate { get; set; }

        [NotMapped]
        public string StatusName { get; set; }
        [NotMapped]
        public string Statusclass { get; set; }
        [NotMapped]
        public string ExitDate0 { get; set; }
        
    }
}
