using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class PatientOverview
    {
        private static readonly HttpClient client = new HttpClient();

        private IEnumerable<Therapist> Patients { get; set; }

        private static readonly String baseURL = "https://localhost:5001/api/patients/";

        protected override async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}all");
            Patients = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>
                     (await streamTask,
                     new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
        }
    }
}
