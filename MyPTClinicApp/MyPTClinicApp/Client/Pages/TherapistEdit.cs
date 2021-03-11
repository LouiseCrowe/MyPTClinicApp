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
    public partial class TherapistEdit
    {
        [Parameter]
        public string TherapistID { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        public Therapist Therapist { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            bool success = int.TryParse(TherapistID, out var therapistID);
            if (!success)
            {
                StatusClass = "alert-danger";
                Message = "Patient ID must be an integer, please try again";
                Saved = false;
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

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async Task HandleValidSubmit()
        {

            Saved = false;

            if (Therapist.ID == 0)       // this means a new therapist is being added
            {
                var addedTherapist = await TherapistService.AddTherapist(Therapist);

                if (addedTherapist != null)
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
                await TherapistService.UpdateTherapist(Therapist);
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

        protected async Task DeleteTherapist()
        {
            await TherapistService.DeleteTherapist(Therapist.ID);

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