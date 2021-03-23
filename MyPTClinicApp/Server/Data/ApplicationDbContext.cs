using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyPTClinicApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser> 
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<MyPTClinicApp.Shared.Therapist> Therapist { get; set; }

        public DbSet<MyPTClinicApp.Shared.Patient> Patient { get; set; }

        public DbSet<MyPTClinicApp.Shared.Treatment> Treatment { get; set; }

        public DbSet<MyPTClinicApp.Shared.SchedulerAppointment> SchedulerAppointment { get; set; }
    }
}
