using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class TreatmentEdit
    {
        [Parameter]
        public string TreatmentID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Patient Patient { get; set; }

        public Therapist Therapist { get; set; }

        public Treatment Treatment { get; set; }

        // for selecting Therapist for treatment
        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();
        
        // for selecting Patient for treatment
        public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();

        //used to store state of screen
        public SavedStatus SavedStatus { get; set; }
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected string ButtonNavigation = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            SavedStatus = SavedStatus.NotSaved;

            bool success = int.TryParse(TreatmentID, out var treatmentID);
            if (!success)
            {
                StatusClass = "alert-danger";
                Message = "Treatment ID must be an integer, please try again";                
            }


            Therapists = await TherapistService.GetTherapists();

            Patients = await PatientService.GetPatients();

            if (treatmentID != 0)       // treatment to be update need to retrieve from db
            {
                Treatment = await TreatmentService.GetTreatmentById(treatmentID);
            }
            else                        // creating new treatment
            {
                Treatment = new Treatment { Date = DateTime.Now };
            }
        }
                
        protected async Task HandleValidSubmit()
        {
            SavedStatus = SavedStatus.NotSaved;

            if (Treatment.ID == 0)       // this means a new treatment is being added
            {
                var addedTreatment = await TreatmentService.AddTreatment(Treatment);

                if (addedTreatment != null)
                {
                    StatusClass = "alert-success";
                    Message = "New treatment added successfully.";
                    SavedStatus = SavedStatus.Saved;
                    ButtonNavigation = "toEdit";
                }
                else
                {
                    // if either the Patient or Therapist are not selected
                    SavedStatus = SavedStatus.Error;
                    StatusClass = "alert-danger";
                    Message = "Treatment not created. Please ensure PATIENT and THERAPIST are selected";
                    ButtonNavigation = "toEdit";
                }
            }
            else    // this is updating an existing patient
            {
                await TreatmentService.UpdateTreatment(Treatment);
                StatusClass = "alert-success";
                Message = "Treatment updated successfully.";
                SavedStatus = SavedStatus.Saved;
                ButtonNavigation = "toOverview";
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        //update for deleting

        protected async Task DeleteTreatment()
        {
            await TreatmentService.DeleteTreatment(Treatment.ID);

            StatusClass = "alert-success";
            Message = "Deleted successfully - Please note the associated appointment was not deleted from the calendar" +
                " and the patient was not emailed.";
            SavedStatus = SavedStatus.Saved;
            ButtonNavigation = "toOverview";
        }



        protected void NavigateToTreatmentOverview()
        {
            NavigationManager.NavigateTo("/treatmentoverview");
        }

        protected async Task NavigateToEditTreatment()
        {
            await OnInitializedAsync();
        }
    }
}
