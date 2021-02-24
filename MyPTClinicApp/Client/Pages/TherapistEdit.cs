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

        // need to have the ID of the therapist that's being edited when 
        // we are in edit mode this page can be in two modes
        // this was Blazor will search for the Therapist ID in the 
        // query string when this component is being invoked
        [Parameter]
        public string TherapistID { get; set; }


        // regardless of mode I will always be data binding on to a therapist
        // so we create a public property we can data bind to
        public Therapist Therapist { get; set; } = new();

        private static readonly HttpClient client = new HttpClient();

        private static readonly String baseURL = "https://localhost:5001/api/therapists/";

        
        // when await added an unhandled error occurred when loading page
        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(TherapistID, out var therapistID);


            if (therapistID == 0)       // new therapist is being created
            {
                // some defaults
                Therapist = new Therapist { Location = "33 Pembroke Street Lower, Dublin 2" };
            }
            else
            {
                var streamTask = client.GetStreamAsync($"{baseURL}id/{TherapistID}");
                Therapist = await JsonSerializer.DeserializeAsync<Therapist>(await streamTask);
            }
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

            if(Therapist.ID == 0)       // this means a new therapist is being added
            { 
                var addedTherapist = new StringContent(JsonSerializer.Serialize(Therapist),
                                            UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PostAsync(baseURL, addedTherapist);
                httpResponse.EnsureSuccessStatusCode();

                var jsonString = await httpResponse.Content.ReadAsStringAsync();

                if (jsonString != null)
                {
                    StatusClass = "alert-success";
                    Message = "New therapist added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new therapist. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                var therapistJson = new StringContent(JsonSerializer.Serialize(Therapist),
                                            Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PutAsync($"{baseURL}id/{Therapist.ID}", therapistJson);

                httpResponse.EnsureSuccessStatusCode();
                StatusClass = "alert-success";
                Message = "Therapist updated successfully.";
                Saved = true;
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
            HttpResponseMessage httpResponse = await client.DeleteAsync($"{baseURL}id/{Therapist.ID}");
            httpResponse.EnsureSuccessStatusCode();

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }



    protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/therapistoverview");
        }

    }

}
