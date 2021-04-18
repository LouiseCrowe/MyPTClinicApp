using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System.Collections.Generic;
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

        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        public Patient Patient { get; set; } = new();

        // for including Therapist Name
        public Therapist Therapist { get; set; } = new();

        // for including Treatment details
        public IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment>();

        protected override async Task OnInitializedAsync()
        {
            Patient = await PatientService.GetPatientById(int.Parse(ID));

            if (Patient != null && Patient.TherapistID.HasValue)
            {
                Therapist = await TherapistService.GetTherapistById(Patient.TherapistID.Value);

                Treatments = await TreatmentService.GetTreatmentsByPatientId(Patient.ID);
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }
    }
}
