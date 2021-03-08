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
    public partial class PatientOverview
    {
        [Inject]
        public IPatientService PatientService { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patients = (await PatientService.GetPatients()).ToList();
        }
    }
}
