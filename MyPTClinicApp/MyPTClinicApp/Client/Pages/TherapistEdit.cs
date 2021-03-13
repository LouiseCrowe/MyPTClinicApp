using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class TherapistEdit
    {
        [Parameter]
        public string TherapistID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Therapist Therapist { get; set; } = new();

        //used to store state of screen
        public SavedStatus SavedStatus { get; set; }
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected string ButtonNavigation = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            SavedStatus = SavedStatus.NotSaved;

            bool success = int.TryParse(TherapistID, out var therapistID);
            if (!success)
            {
                StatusClass = "alert-danger";
                Message = "Therapist ID must be an integer, please try again";
                SavedStatus = SavedStatus.NotSaved;
            }

            if (therapistID == 0)       // new therapist is being created
            {
                // some defaults
                Therapist = new Therapist { Location = "33 Pembroke Street Lower, Dublin 2" };
            }
            else
            {
                // fetch therapist from db
                Therapist = await TherapistService.GetTherapistById(int.Parse(TherapistID));              
            }
        }

        
        protected async Task HandleValidSubmit()
        {
            SavedStatus = SavedStatus.NotSaved;

            if (Therapist.ID == 0)       // this means a new therapist is being added
            {
                var addedTherapist = await TherapistService.AddTherapist(Therapist);

                if (addedTherapist != null)
                {
                    StatusClass = "alert-success";
                    Message = "New therapist added successfully.";
                    SavedStatus = SavedStatus.Saved;
                }
                else
                {
                    // if there's a duplicate full name
                    SavedStatus = SavedStatus.Error;
                    StatusClass = "alert-danger";
                    Message = "Therapist name already in use. Please try again.";
                    ButtonNavigation = "toAdd";
                }
            }
            else                 // updating therapist
            {
                var response = await TherapistService.UpdateTherapist(Therapist);
                //if (response != null)           // Bad request returned instead of null
                //{
                    StatusClass = "alert-success";
                    Message = "Therapist updated successfully.";
                    SavedStatus = SavedStatus.Saved;
                    ButtonNavigation = "toOverview";
            //}
            //else
            //{ 
            //    SavedStatus = SavedStatus.Error;
            //    StatusClass = "alert-danger";
            //    Message = "Therapist name already in use. Please try again.";
            //}
        }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteTherapist()
        {
            await TherapistService.DeleteTherapist(Therapist.ID);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            ButtonNavigation = "toOverview";
            SavedStatus = SavedStatus.Saved;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/therapistoverview");
        }

        protected async Task NavigateToEditTherapist()
        {
            await OnInitializedAsync();
        }
    }

}