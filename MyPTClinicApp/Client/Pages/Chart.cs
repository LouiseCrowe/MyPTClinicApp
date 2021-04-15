using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class Chart
    {
        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        private IEnumerable<TreatmentDTO> Treatments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments

            GetDataForXAxis(currentMonth);
            GetDataForChart(currentMonth);                                                                        
        }


        int currentMonth = DateTime.Now.Month;

        int currentYear = DateTime.Now.Year;

        // create List to include date for year up to current date
        private List<DataModel> modelData = new() { };

        // label xAxis based on current month       
        public string[] xAxisItems = new string[DateTime.Now.Month];

        public List<string> Months = new List<string> { "January", "February", "March", "April", "May",
                    "June", "July", "August", "September", "October", "November", "December"};

        protected List<DataModel> GetDataForChart(int currentMonth)
        {
            for (int i = 0; i < currentMonth; i++)
            {
                modelData.Add(new DataModel()
                {
                    Month = Months[i],
                    MonthlyTotal = Treatments.Count(t => t.Date.Month == (i + 1))
                });
            }

            return modelData;
        }

        
        public class DataModel
        {
            public int MonthlyTotal { get; set; }
            public string Month { get; set; }
        }


        protected string[] GetDataForXAxis(int currentMonth)
        {
            for (int i = 0; i < currentMonth; i++)
            {
                xAxisItems[i] = Months[i];
            }

            return xAxisItems.ToArray();
        }

       
    }
}

