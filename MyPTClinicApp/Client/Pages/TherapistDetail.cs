using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class TherapistDetail
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }
        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Therapist Therapist { get; set; } = new();

         public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();

        protected override async Task OnInitializedAsync()
        {
            Therapist = await TherapistService.GetTherapistById(int.Parse(ID));

            if (Therapist != null)
            {
                Patients = await PatientService.GetPatientsByTherapistId(Therapist.ID);
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/therapistoverview");
        }
    }
}
