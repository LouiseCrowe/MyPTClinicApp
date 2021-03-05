using Microsoft.AspNetCore.Components;
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

        public Treatment Treatment { get; set; } = new();
        
        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/treatments/";

        // needed for selecting therapist 
        private static readonly String therapistURL = "https://localhost:5001/api/therapists/";

        public IEnumerable<Therapist> Therapists { get; set; } = new List<Therapist>();

        // needed for selecting patient 
        private static readonly String patientURL = "https://localhost:5001/api/patients/";

        public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(TreatmentID, out var treatmentID);

            // get a list of all valid therapists
            var streamTaskTherapists = client.GetStreamAsync($"{therapistURL}all");
            Therapists = await JsonSerializer.DeserializeAsync<IEnumerable<Therapist>>
                       (await streamTaskTherapists,
                       new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            // get a list of all valid patients
            var streamTaskPatients = client.GetStreamAsync($"{patientURL}all");
            Patients = await JsonSerializer.DeserializeAsync<IEnumerable<Patient>>
                                                (await streamTaskPatients,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (treatmentID != 0)       // this is a patient to be updated so get json stream from db
            {
                var streamTaskTreatment = client.GetStreamAsync($"{baseURL}id/{treatmentID}");
                Treatment = await JsonSerializer.DeserializeAsync<Treatment>(await streamTaskTreatment,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Treatment = new Treatment { Date = DateTime.Now };
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

            if (Treatment.ID == 0)       // this means a new treatment is being added
            {
                var addedTreatment = new StringContent(JsonSerializer.Serialize(Treatment),
                                            UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PostAsync(baseURL, addedTreatment);
                httpResponse.EnsureSuccessStatusCode();

                var jsonString = await httpResponse.Content.ReadAsStringAsync();

                if (jsonString != null)
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
                var treatmentJson = new StringContent(JsonSerializer.Serialize(Treatment),
                                            Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PutAsync($"{baseURL}id/{Treatment.ID}",
                                                                            treatmentJson);

                httpResponse.EnsureSuccessStatusCode();
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
            HttpResponseMessage httpResponse = await client.DeleteAsync($"{baseURL}id/{Treatment.ID}");
            httpResponse.EnsureSuccessStatusCode();

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
