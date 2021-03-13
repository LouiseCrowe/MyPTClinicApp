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

        // properties for search
        public string SearchName { get; set; }

        //private bool found;

        private string errormessage;

        protected override async Task OnInitializedAsync()
        {
            Therapists = (await TherapistService.GetTherapists()).ToList();
        }


        public async Task Search()
        {
            try
            {
                Therapists = await TherapistService.Search(SearchName);
                //found = true;
                errormessage = String.Empty;
            }
            catch (Exception)
            {
                //found = false;
                errormessage = "Name not found - maybe check your spelling or try another name";
            }
            
            
        }

        public async Task ClearSearch()
        {
            SearchName = String.Empty;
            Therapists = await TherapistService.GetTherapists();
        }
    }
}
