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
    public partial class TreatmentDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Patient Patient { get; set; } = new();

        public Therapist Therapist { get; set; } = new();

        public Treatment Treatment { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Treatment = await TreatmentService.GetTreatmentById(int.Parse(ID));

            if (Treatment != null)
            {
                if (Treatment.PatientID != 0)
                {
                    Patient = await PatientService.GetPatientById(Treatment.PatientID);
                }
                if (Treatment.TherapistID != 0)
                {
                    Therapist = await TherapistService.GetTherapistById(Treatment.TherapistID);
                }
            }
        }

        protected void NavigateToTreatmentOverview()
        {
            NavigationManager.NavigateTo("/treatmentoverview");
        }
    }
}
