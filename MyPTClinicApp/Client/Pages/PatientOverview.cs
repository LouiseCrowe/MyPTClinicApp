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
        
        // for pagination
        public IEnumerable<Patient> PatientList { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        
        // for managing search
        public string SearchName { get; set; }
        string[] fullName;
        string searchName = "";
        string lastName = "";
        private string errormessage;

        protected override async Task OnInitializedAsync()
        {
            Patients = (await PatientService.GetPatients()).ToList();

            // for pagination
            PageSize = 10;
            PatientList = Patients.Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Patients.Count() / (decimal)PageSize);
        }


        // for pagination
        private void UpdateList(int pageNumber = 0)
        {
            // pageNumber * PageSize -> take 10
            PatientList = Patients.Skip(pageNumber * PageSize).Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Patients.Count() / (decimal)PageSize);
            CurrentPage = pageNumber;
        }

        private void NavigateTo(string direction)
        {
            if (direction == "prev" && CurrentPage !=0)
            {
                CurrentPage -= 1;
            }
            if (direction == "next" && CurrentPage != TotalPages -1)
            {
                CurrentPage += 1;
            }
            if (direction == "first" )
            {
                CurrentPage = 0;
            }
            if (direction == "last")
            {
                CurrentPage = TotalPages - 1;
            }

            UpdateList(CurrentPage);
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
                UpdateList();

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
            UpdateList();
            errormessage = string.Empty;
        }
    }
}
