﻿using Microsoft.AspNetCore.Components;
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
        
        // to allow navigation back to overview
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        // needed to select therapists for patient
        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Patient Patient { get; set; } = new ();

        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();

        //used to store state of screen
        public SavedStatus SavedStatus { get; set; }
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected string ButtonNavigation = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            SavedStatus = SavedStatus.NotSaved;

            bool success = int.TryParse(PatientID, out var patientID);
            if (!success)
            {
                StatusClass = "alert-danger";
                Message = "Patient ID must be an integer, please try again";
                SavedStatus = SavedStatus.NotSaved;
            }

            // complete list of therapists for input select in EditForm
            Therapists = await TherapistService.GetTherapists();

            if (patientID == 0)      // new patient - include default therapist
            {
                Patient = new Patient { TherapistID = 1 };         // set all patient to therapist 1
                
            }
            else                      // patient to be updated 
            {
                Patient = await PatientService.GetPatientById(patientID);
            }
        }

        protected async Task HandleValidSubmit()
        {
            SavedStatus = SavedStatus.NotSaved;

            if (Patient.ID == 0)       // this means a new patient is being added
            {
                var addedPatient = await PatientService.AddPatient(Patient);
                
                if (addedPatient != null)
                {
                    StatusClass = "alert-success";
                    Message = "New patient added successfully.";
                    SavedStatus = SavedStatus.Saved;
                    ButtonNavigation = "toAdd";
                }
                else
                {
                    // if there's a duplicate full name
                    SavedStatus = SavedStatus.Error;
                    StatusClass = "alert-danger";
                    Message = "Patient name already in use. Please try again.";
                    ButtonNavigation = "toAdd";
                }
            }
            else    // this is updating an existing patient
            {
                var response = await PatientService.UpdatePatient(Patient);

                if (response != null)
                {
                    StatusClass = "alert-success";
                    Message = "Patient updated successfully.";
                    SavedStatus = SavedStatus.Saved;
                    ButtonNavigation = "toOverview";
                }
                else
                {
                    SavedStatus = SavedStatus.Error;
                    StatusClass = "alert-danger";
                    Message = "Patient name already in use. Please try again.";
                    ButtonNavigation = "toOverview";
                }
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
            ButtonNavigation = "toOverview";
            SavedStatus = SavedStatus.Saved;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/patientoverview");
        }

        protected async Task NavigateToEditPatient()
        {
            await OnInitializedAsync();
        }
    }
}