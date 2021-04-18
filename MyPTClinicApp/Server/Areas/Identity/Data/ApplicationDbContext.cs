using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyPTClinicApp.Shared.Therapist> Therapist { get; set; }

        public DbSet<MyPTClinicApp.Shared.Patient> Patient { get; set; }

        public DbSet<MyPTClinicApp.Shared.Treatment> Treatment { get; set; }

        public DbSet<MyPTClinicApp.Shared.SchedulerAppointment> SchedulerAppointment { get; set; }
    }
}
