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

        // for pagination
        public IEnumerable<Therapist> TherapistList { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Therapists = (await TherapistService.GetTherapists()).ToList();

            // for pagination
            PageSize = 3;
            TherapistList = Therapists.Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Therapists.Count() / (decimal)PageSize);
        }

        // for pagination
        private void UpdateList(int pageNumber = 0)
        {
            // pageNumber * PageSize -> take 5
            TherapistList = Therapists.Skip(pageNumber * PageSize).Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Therapists.Count() / (decimal)PageSize);
            CurrentPage = pageNumber;
        }

        private void NavigateTo(string direction)
        {
            if (direction == "prev" && CurrentPage != 0)
            {
                CurrentPage -= 1;
            }
            if (direction == "next" && CurrentPage != TotalPages - 1)
            {
                CurrentPage += 1;
            }
            if (direction == "first")
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

                Therapists = await TherapistService.Search(searchName, lastName);
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
            Therapists = await TherapistService.GetTherapists();
            UpdateList();
            errormessage = string.Empty;
        }
    }
}
