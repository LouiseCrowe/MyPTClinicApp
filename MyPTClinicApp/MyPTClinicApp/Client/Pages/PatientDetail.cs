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

        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Patient Patient { get; set; } = new();

        public Therapist Therapist { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Patient = await PatientService.GetPatientById(int.Parse(ID));

            if (Patient != null && Patient.TherapistID.HasValue)
            {
                Therapist = await TherapistService.GetTherapistById(Patient.TherapistID.Value);               
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }
    }
}
