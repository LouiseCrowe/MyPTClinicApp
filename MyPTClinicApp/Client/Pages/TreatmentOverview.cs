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
    public partial class TreatmentOverview
    {
        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        private IEnumerable<TreatmentDTO> Treatments { get; set; }

        // for managing search
        public string SearchName { get; set; }
        string[] fullName;
        string searchName = "";
        string lastName = "";
        public DateTime FromDate { get; set; } = new DateTime(2021, 01, 01);
        public DateTime ToDate { get; set; } = DateTime.Now;
        private string errormessage;
        
        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();
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

                Treatments = await TreatmentService.Search(searchName, lastName, FromDate, ToDate);

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
            Treatments = await TreatmentService.GetTreatments();
            errormessage = string.Empty;
        }

    }
}