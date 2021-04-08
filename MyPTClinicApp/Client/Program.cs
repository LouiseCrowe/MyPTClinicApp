using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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

            builder.Services.AddHttpClient("MyPTClinicApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyPTClinicApp.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

            builder.Services.AddHttpClient<IEmailService, EmailService>();
            builder.Services.AddScoped<EmailService>();

            builder.Services.AddScoped<ITherapistService, TherapistService>();

            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddScoped<ITreatmentService, TreatmentService>();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            // register the Telerik services
            builder.Services.AddTelerikBlazor();

            await builder.Build().RunAsync();
        }
    }
}
