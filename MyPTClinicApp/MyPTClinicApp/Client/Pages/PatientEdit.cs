using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class PatientEdit
    {
        [Parameter]
        public string PatientID { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        // needed to select therapists for patient
        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Patient Patient { get; set; } = new ();

        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            bool success = int.TryParse(PatientID, out var patientID);
            if (!success)
            {
                StatusClass = "alert-danger";
                Message = "Patient ID must be an integer, please try again";
                Saved = false;
            }

            // complete list of therapists for input select in EditForm
            Therapists = await TherapistService.GetTherapists();

            if (patientID != 0)       // this is a patient to be updated so get json stream from db
            {
                Patient = await PatientService.GetPatientById(patientID);
            }
            else                     // include default therapist for all new patients
            {
                Patient = new Patient { TherapistID = 1 };         // set all patient to therapist 1
            }
        }

        // to allow navigation back to overview
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        
        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Patient.ID == 0)       // this means a new patient is being added
            {
                var addedPatient = await PatientService.AddPatient(Patient);
                
                if (addedPatient != null)
                {
                    StatusClass = "alert-success";
                    Message = "New patient added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new patient. Please try again.";
                    Saved = false;
                }
            }
            else    // this is updating an existing patient
            {
                await PatientService.UpdatePatient(Patient);
                StatusClass = "alert-success";
                Message = "Patient updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        //update for deleting

        protected async Task DeletePatient()
        {
            await PatientService.DeletePatient(Patient.ID);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }
    }
}
