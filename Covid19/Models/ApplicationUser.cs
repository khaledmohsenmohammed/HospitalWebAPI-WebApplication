﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public int HospitalId { get; set; }
        public Hospital hospital { get; set; }
    }
}
