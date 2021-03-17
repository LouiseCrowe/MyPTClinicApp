using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class TherapistOverview
    {
        [Inject]
        public ITherapistService TherapistService { get; set; }

        private IEnumerable<Therapist> Therapists { get; set; }

        // for managing search
        public string SearchName { get; set; }
        string[] fullName;
        string searchName = "";
        string lastName = "";
        private string errormessage;

        protected override async Task OnInitializedAsync()
        {
            Therapists = (await TherapistService.GetTherapists()).ToList();
        }

        public async Task Search()
        {
            try
            {
                fullName = SearchName.Split(" ");
                searchName = fullName[0];
                if (fullName.Length > 1)
                {
                    lastName = fullName[^1];
                }
                else
                {
                    lastName = fullName[0];         // this allows user to search by just first or last name
                }

                Therapists = await TherapistService.Search(searchName, lastName);

                errormessage = String.Empty;
            }
            catch (Exception)
            {
                errormessage = "Name not found - maybe check your spelling or try another name";
            }           
        }

        public async Task ClearSearch()
        {
            SearchName = String.Empty;
            Therapists = await TherapistService.GetTherapists();
            errormessage = string.Empty;
        }
    }
}
