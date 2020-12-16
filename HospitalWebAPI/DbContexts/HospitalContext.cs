using HospitalWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.DbContexts
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {}

        public DbSet<AdminApplicationUser> AdminApplicationUser { get; set; }
      
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Patient> Patient { get; set; }

    }
}
