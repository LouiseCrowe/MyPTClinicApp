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
    public partial class TherapistOverview
    {
        [Inject]
        public ITherapistService TherapistService { get; set; }

        private IEnumerable<Therapist> Therapists { get; set; }

        private IEnumerable<Patient> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Therapists = (await TherapistService.GetTherapists()).ToList();              
        }
    }
}
