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
    public partial class PatientOverview
    {
        [Inject]
        public IPatientService PatientService { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        // for managing search
        public string SearchName { get; set; }
        string[] fullName;
        string searchName = "";
        string lastName = "";
        private string errormessage;

        protected override async Task OnInitializedAsync()
        {
            Patients = (await PatientService.GetPatients()).ToList();
        }

        public async Task Search()
        {
            try
            {
                fullName = SearchName.Trim().Split(" ");
                searchName = fullName[0];
                if (fullName.Length > 1)
                {
                    lastName = fullName[^1];
                }
                else
                {
                    lastName = fullName[0];         // this allows user to search by just first or last name
                }

                Patients = await PatientService.Search(searchName, lastName);

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
            Patients = await PatientService.GetPatients();
            errormessage = string.Empty;
        }
    }
}
