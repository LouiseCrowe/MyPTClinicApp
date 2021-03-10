﻿using Microsoft.AspNetCore.Components;
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
    public partial class TreatmentDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Treatment Treatment { get; set; } = new();

        public Therapist Therapist { get; set; } = new();
        public Patient Patient { get; set; } = new();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/treatments/";

        private static readonly String patientBaseURL = "https://localhost:5001/api/patients/";

        private static readonly String therapistBaseURL = "https://localhost:5001/api/therapists/";

        protected override async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}id/{ID}");
            Treatment = await JsonSerializer.DeserializeAsync<Treatment>(await streamTask,
                       new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            if (Treatment.PatientID != 0)
            {
                var streamTaskPatient = client.GetStreamAsync($"{patientBaseURL}id/{Treatment.PatientID}");
                Patient = await JsonSerializer.DeserializeAsync<Patient>(await streamTaskPatient,
                            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }


            if (Treatment.TherapistID != 0)
            {
                var streamTaskTherapist = client.GetStreamAsync($"{therapistBaseURL}id/{Treatment.TherapistID}");
                Therapist = await JsonSerializer.DeserializeAsync<Therapist>(await streamTaskTherapist,
                           new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }
    }
}