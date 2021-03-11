using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public Patient Patient { get; set; } = new();

        public Therapist Therapist { get; set; } = new();

        public Treatment Treatment { get; set; } = new();

        // for selecting Therapist for treatment
        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();
        
        // for selecting Patient for treatment
        public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(TreatmentID, out var treatmentID);

            Therapists = await TherapistService.GetTherapists();

            Patients = await PatientService.GetPatients();

            if (treatmentID != 0)       // this is a treatment to be updated so get json stream from db
            {
                Treatment = await TreatmentService.GetTreatmentById(treatmentID);
            }
            else                        // creating new treatment
            {
                Treatment = new Treatment { Date = DateTime.Now };
            }
        }
                
        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Treatment.ID == 0)       // this means a new treatment is being added
            {
                var addedTreatment = await TreatmentService.AddTreatment(Treatment);

                if (addedTreatment != null)
                {
                    StatusClass = "alert-success";
                    Message = "New treatment added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new treatment. Please try again.";
                    Saved = false;
                }
            }
            else    // this is updating an existing patient
            {
                await TreatmentService.UpdateTreatment(Treatment);
                StatusClass = "alert-success";
                Message = "Treatment updated successfully.";
                Saved = true;
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
            Message = "Deleted successfully";

            Saved = true;
        }



        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/treatmentoverview");
        }

    }
}
