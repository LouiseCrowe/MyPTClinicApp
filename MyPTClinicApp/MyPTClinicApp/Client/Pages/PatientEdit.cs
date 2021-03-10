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
    public partial class PatientEdit
    {
        [Parameter]
        public string PatientID { get; set; }

        public Patient Patient { get; set; } = new ();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/patients/";

        // needed for inputting therapist 
        private static readonly String therapistURL = "https://localhost:5001/api/therapists/";

        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();

        //protected string TherapistID = string.Empty;

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
            
            // get a list of all valid therapists to include in patient detail
            var streamTaskTherapists = client.GetStreamAsync($"{therapistURL}all");
            Therapists = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>
                         (await streamTaskTherapists,
                       new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (patientID != 0)       // this is a patient to be updated so get json stream from db
            {
                var streamTaskPatient = client.GetStreamAsync($"{baseURL}id/{patientID}");
                Patient = await JsonSerializer.DeserializeAsync<Patient>(await streamTaskPatient,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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
                var addedPatient = new StringContent(JsonSerializer.Serialize(Patient),
                                            UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PostAsync(baseURL, addedPatient);
                httpResponse.EnsureSuccessStatusCode();

                var jsonString = await httpResponse.Content.ReadAsStringAsync();

                if (jsonString != null)
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
                var therapistJson = new StringContent(JsonSerializer.Serialize(Patient),
                                            Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PutAsync($"{baseURL}id/{Patient.ID}", 
                                                                            therapistJson);

                httpResponse.EnsureSuccessStatusCode();
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
            HttpResponseMessage httpResponse = await client.DeleteAsync($"{baseURL}id/{Patient.ID}");
            httpResponse.EnsureSuccessStatusCode();

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
