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
        public DateTime FromDate { get; set; } = new DateTime(2020, 01, 01);
        public DateTime ToDate { get; set; } = DateTime.Now;
        private string errormessage;

        // for showing summary
        protected bool showSummary = false;


        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments    
            totalTreatments = Treatments.Count();                       // this figure will remain the same

            // for breakdown display - will include all treatments in initial rendering
            GroupByPatientID();
            GroupByTherapistID();
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

                Treatments = await TreatmentService.Search(searchName, lastName, FromDate, ToDate);

                PatientsWithTreatments = new List<List<TreatmentDTO>>();  // reset Patients with treatments 
                                                                          // so summary reflects search results
                GroupByPatientID();                 // re-run query to include only search results

                TherapistsWithTreatments = new List<List<TreatmentDTO>>();  // reset Patients with treatments 
                                                                          // so summary reflects search results
                GroupByTherapistID();                 // re-run query to include only search results

                errormessage = String.Empty;
            }
            catch (Exception)
            {
                errormessage = "No treatments match the search criteria, please try again.";
            }
        }

        public async Task ClearSearch()
        {
            SearchName = String.Empty;
            Treatments = await TreatmentService.GetTreatments();
            errormessage = string.Empty;
        }


        public void ResetDates()
        {
            FromDate = new DateTime(2020, 01, 01);
            ToDate = DateTime.Now;
        }

        public void ShowSummary()
        {
            showSummary = true;
        }

        public void HideSummary()
        {
            showSummary = false;
        }

        public void GroupByPatientID()
        {
            var query = from treatment in Treatments
                        group treatment by treatment.PatientId;

            foreach (var group in query)
            {
                PatientsWithTreatments.Add(group.ToList());
            }
        }

        public void GroupByTherapistID()
        {
            var query = from treatment in Treatments
                        group treatment by treatment.TherapistId;

            foreach (var group in query)
            {
                TherapistsWithTreatments.Add(group.ToList());
            }
        }


    }
}