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
        // for navigating to treatment edit
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        private IEnumerable<TreatmentDTO> Treatments { get; set; }

        private int totalTreatments;

        // for breakdown information 
        List<List<TreatmentDTO>> PatientsWithTreatments = new ();     
        List<List<TreatmentDTO>> TherapistsWithTreatments = new ();

        // for managing search
        public string SearchName { get; set; } = new string("");      // to allow initial search for all treatment
                                                                      // without searching for a specific name
        string[] fullName;
        string searchName = "";
        string lastName = "";

        // need to include time 0, 0, 0 to ensure all treatments are included, based on treatment start time
        public DateTime FromDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        public DateTime ToDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        private string errormessage;

        // for showing summary
        protected bool showSummary = false;

        // for pagination
        public IEnumerable<TreatmentDTO> TreatmentList { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments    
            totalTreatments = Treatments.Count();                       // this figure will remain the same regardless of search criteria

            // for breakdown display - includes all treatments in initial rendering
            GroupByPatientID();
            GroupByTherapistID();

            // for pagination
            PageSize = 10;
            TreatmentList = Treatments.Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Treatments.Count() / (decimal)PageSize);
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

                // need to add a day because the time for the ToDate is 12AM otherwise treatments 
                // would not be included as the treatment start time will always be greater than 12AM!
                ToDate = ToDate.AddDays(1);

                Treatments = await TreatmentService.Search(searchName, lastName, FromDate, ToDate);

                // need to reset date display back to the user selected date as soon as the treatments are retrieved and displayed
                ToDate = ToDate.AddDays(-1);

                UpdateBreakdownInfoAfterSearch();
            }
            catch (Exception)
            {
                // need to reset display date if search does not retrieve any records
                ToDate = ToDate.AddDays(-1);
                errormessage = "No treatments match the search criteria, please try again.";
            }
        }

        private void UpdateBreakdownInfoAfterSearch()
        {
            PatientsWithTreatments = new List<List<TreatmentDTO>>();  // reset Patients with treatments 
                                                                      // so summary reflects search results
            GroupByPatientID();                 // re-run query to include only search results

            TherapistsWithTreatments = new List<List<TreatmentDTO>>();  // reset Patients with treatments 
                                                                        // so summary reflects search results
            GroupByTherapistID();                 // re-run query to include only search results

            errormessage = String.Empty;
            UpdateList();
        }       

        public async Task ClearSearch()
        {
            SearchName = String.Empty;
            Treatments = await TreatmentService.GetTreatments();
            UpdateBreakdownInfoAfterSearch();
            errormessage = string.Empty;
        }

        public void ResetDates()
        {
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        public void ShowSummary()
        {
            showSummary = true;
        }

        public void HideSummary()
        {
            showSummary = false;
        }

        // for finding how many treatments each patient received
        public void GroupByPatientID()
        {
            var query = from treatment in Treatments
                        group treatment by treatment.PatientId;

            foreach (var group in query)
            {
                PatientsWithTreatments.Add(group.ToList());
            }
        }

        // for finding how many treatments each therapists performed
        public void GroupByTherapistID()
        {
            var query = from treatment in Treatments
                        group treatment by treatment.TherapistId;

            foreach (var group in query)
            {
                TherapistsWithTreatments.Add(group.ToList());
            }
        }


        public void NavigateToTreatmentEdit()
        {
            NavigationManager.NavigateTo("/treatmentedit");
        }

        // for pagination
        private void UpdateList(int pageNumber = 0)
        {
            // pageNumber * PageSize -> take 10
            TreatmentList = Treatments.Skip(pageNumber * PageSize).Take(PageSize).ToList();
            TotalPages = (int)Math.Ceiling(Treatments.Count() / (decimal)PageSize);
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
    }
}