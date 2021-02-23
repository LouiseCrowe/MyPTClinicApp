using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class TherapistEdit
    {
        [Parameter]
        public string TherapistID { get; set; }

        public Therapist Therapist { get; set; } = new();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/therapists/";

        protected async Task OnInitializedAsync()
        {
            var streamTask = client.GetStreamAsync($"{baseURL}id/{TherapistID}");
            Therapist = await JsonSerializer.DeserializeAsync<Therapist>(await streamTask);
        }


        [Inject]
        public NavigationManager NavigationManager { get; set; }


        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async Task HandleValidSubmit()
        {
            Saved = false;


            if (Therapist.ID == 0) //new
            {
                // code to add employee

                Therapist = new Therapist
                {
                    FirstName = Therapist.FirstName,
                    LastName = Therapist.LastName,
                    Phone = Therapist.Phone,
                    Email = Therapist.Email,
                    Location = Therapist.Location
                };

                var stringContent = new StringContent(JsonSerializer.Serialize(Therapist),
                                            UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PostAsync(baseURL, stringContent);
                httpResponse.EnsureSuccessStatusCode();

                var jsonString = await httpResponse.Content.ReadAsStringAsync();

                if (jsonString != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }

        }



        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        //update for deleting

        protected async Task DeleteTherapist()
        {
            //    await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            //    StatusClass = "alert-success";
            //    Message = "Deleted successfully";

            //    Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/therapistoverview");
        }

    }

}
