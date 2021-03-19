
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyPTClinicApp.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

            builder.Services.AddScoped<ITherapistService, TherapistService>();

            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddScoped<ITreatmentService, TreatmentService>();

            // register the Telerik services
            builder.Services.AddTelerikBlazor();

            await builder.Build().RunAsync();
        }
    }
}
