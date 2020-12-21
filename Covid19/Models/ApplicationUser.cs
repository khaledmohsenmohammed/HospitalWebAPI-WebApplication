using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("المستشفى")]
        public int HospitalId { get; set; }
        public Hospital hospital { get; set; }
        [EmailAddress(ErrorMessage ="ادخل ايميل صحيح")]
        [DisplayName("الايميل")]
        public override string Email { get => base.Email    ; set => base.Email = value; }
        [DisplayName("الموبايل")]
        public override string PhoneNumber { get => base.PhoneNumber    ; set => base.PhoneNumber = value; }
    }
}
