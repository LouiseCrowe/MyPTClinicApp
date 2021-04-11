using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyPTClinicApp.Client.Pages
{
    public partial class PatientEdit
    {
        [Parameter]
        public string PatientID { get; set; }
        
        // to allow navigation back to overview
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // for sending welcome mail
        [Inject]
        public IEmailService EmailService { get; set; }

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
                    ButtonNavigation = "toAdd";                 // "toAdd" has option to add another patient
                                                                // and send Welcome Email                            
                }
                else
                {
                    // if there's a duplicate full name
                    StatusClass = "alert-danger";
                    Message = "Patient name already in use. Please try again.";
                    SavedStatus = SavedStatus.Error;
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

        protected async Task SendWelcomeMail()
        {

            if (Patient.Email == null)
            {
                SavedStatus = SavedStatus.Error;
                StatusClass = "alert-danger";
                Message = $"{Patient.FirstName} {Patient.LastName} has not provided an email address";
                ButtonNavigation = "toOverview";
            }


            SendGridMessage msg = new SendGridMessage();
            EmailAddress from = new EmailAddress("dylan@dylancroweclinic.ie", "Dylan Crowe");
            EmailAddress recipient = new EmailAddress(Patient.Email, $"{Patient.FirstName} {Patient.LastName}");

            msg.SetSubject($"Welcome to Dylan Crowe Physical Therapy Clinic");
            msg.SetFrom(from);
            msg.AddTo(recipient);
            msg.PlainTextContent = $"Dear {Patient.FirstName}" +
                         $"\n\nWe are delighted you will be attending our clinic.  " +
                         $"Please call or text on 087 7774512 to make an appointment." +                         
                         $"\n\nKind regards," +
                         $"\n\nDylan Crowe" +
                         $"\n\nPhone Number: 087 7774512" +
                         $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                         $"\nWebsite: https://dylancroweclinic.ie/";


            bool response = await EmailService.SendEmail(msg);
            if (response)
            {
                StatusClass = "alert-success";
                Message = "Welcome Email Sent";
                ButtonNavigation = "toOverview";
                SavedStatus = SavedStatus.EmailSent;
            }
            else
            {
                SavedStatus = SavedStatus.Error;
                StatusClass = "alert-danger";
                Message = "Email not sent";
                ButtonNavigation = "toOverview";
            }

        }

        protected async Task NavigateToEditPatient()
        {
            await OnInitializedAsync();
        }
    }
}
