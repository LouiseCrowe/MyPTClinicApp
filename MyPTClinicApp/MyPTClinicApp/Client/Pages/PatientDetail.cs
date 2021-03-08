using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
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
    public partial class PatientDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        public Patient Patient { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Patient = await PatientService.GetPatientById(int.Parse(ID));
        }



        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }


        //Original not abstracted PatientDetail Service
        //public Therapist Therapist { get; set; } = new();

        //private static readonly HttpClient client = new HttpClient();

        //private static readonly String baseURL = "https://localhost:5001/api/patients/";

        //private static readonly String therapistBaseURL = "https://localhost:5001/api/therapists/";

        //protected override async Task OnInitializedAsync()
        //{
        //    var streamTask = client.GetStreamAsync($"{baseURL}id/{ID}");
        //    Patient = await JsonSerializer.DeserializeAsync<Patient>
        //        (await streamTask, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        //    var streamTaskTherapist = client.GetStreamAsync($"{therapistBaseURL}id/{Patient.TherapistID}");
        //    Therapist = await JsonSerializer.DeserializeAsync<Therapist>(await streamTaskTherapist,
        //                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}

    }
}
