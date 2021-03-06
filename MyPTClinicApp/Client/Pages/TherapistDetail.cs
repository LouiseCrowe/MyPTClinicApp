using Microsoft.AspNetCore.Components;
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
    public partial class TherapistDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Therapist Therapist { get; set; } = new();

        public IEnumerable<Therapist> Patients { get; set; } = new List<Therapist>();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/therapists/";

        private static readonly String patientBaseURL = "https://localhost:5001/api/patients/";

        protected override async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}id/{ID}");
            Therapist = await JsonSerializer.DeserializeAsync<Therapist>(await streamTask,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var streamTaskPatients = client.GetStreamAsync($"{patientBaseURL}therapistid/{ID}");
            Patients = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>(await streamTaskPatients,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/therapistoverview");
        }


    }
}
