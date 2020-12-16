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
        public DbSet<AdminApplicationUser> Courses { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}
