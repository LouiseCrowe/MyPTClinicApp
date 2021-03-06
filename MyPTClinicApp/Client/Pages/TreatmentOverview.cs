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
    public partial class TreatmentOverview
    {
        private static readonly HttpClient client = new HttpClient();

        private IEnumerable<Treatment> Treatments { get; set; }
               

        private static readonly String baseURL = "https://localhost:5001/api/treatments/";

        // to display therapist info        
        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();
        private static readonly String therapistBaseURL = "https://localhost:5001/api/therapists/";

        // to display patient info
        public IEnumerable<Therapist> Patients { get; set; } = new List<Therapist>();
        private static readonly String patientBaseURL = "https://localhost:5001/api/patients/";

        protected override async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}all");
            Treatments = await JsonSerializer.DeserializeAsync<IEnumerable<Treatment>>
                 (await streamTask, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var streamTaskTherapist = client.GetStreamAsync($"{therapistBaseURL}all");
            Therapists = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>
                  (await streamTaskTherapist, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var streamTaskPatients = client.GetStreamAsync($"{patientBaseURL}all");
            Patients = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>
                 (await streamTaskPatients, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}