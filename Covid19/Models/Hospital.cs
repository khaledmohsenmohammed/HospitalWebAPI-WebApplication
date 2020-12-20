using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    [Table("Hospital", Schema = "dbo")]
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("اسم الجهة")]
        public string HName { get; set; }
        [DisplayName("مستشفى")]
        public bool IsAdmin { get ; set; } //true = Hospital False = Moderea

        [DisplayName("عدد الأسرة")]
        public int ICUBeds { get; set; }

        [DisplayName("عدد أجهزة التنفس")]
        public int ICUVents { get; set; }

 

    }
}
