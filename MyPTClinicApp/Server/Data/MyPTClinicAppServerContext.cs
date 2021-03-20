using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Shared;

namespace MyPTClinicApp.Server.Data
{
    public class MyPTClinicAppServerContext : DbContext
    {
        public MyPTClinicAppServerContext (DbContextOptions<MyPTClinicAppServerContext> options)
            : base(options)
        {           
        }

        public DbSet<MyPTClinicApp.Shared.Therapist> Therapist { get; set; }

        public DbSet<MyPTClinicApp.Shared.Patient> Patient { get; set; }

        public DbSet<MyPTClinicApp.Shared.Treatment> Treatment { get; set; }

        public DbSet<MyPTClinicApp.Shared.SchedulerAppointment> SchedulerAppointment { get; set; }
       
    }
}
