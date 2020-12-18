using Covid19.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hospital> hospitals { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Covid19.Models.ExitStatus> ExitStatus { get; set; }
    }
}
