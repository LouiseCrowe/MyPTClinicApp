using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class PatientDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Patient Patient { get; set; } = new();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/patients/";

        protected override async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}id/{ID}");
            Patient = await JsonSerializer.DeserializeAsync<Patient>(await streamTask);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }
    }
}
