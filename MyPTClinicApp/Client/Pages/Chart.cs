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

        private IEnumerable<TreatmentDto> Treatments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments

            GetDataForXAxis(currentMonth);
            GetDataForCurrentYear(currentMonth);
            GetDataForLastYear(currentMonth);
        }

        private readonly int currentMonth = DateTime.Now.Month;
        private readonly int numItemsInXAxis = (DateTime.Now.Month + 1);                     // need extra space for "total"
        private readonly int currentYear = DateTime.Now.Year;
        private readonly int lastYear = (DateTime.Now.Year -1);
        private int currentYearTotal;
        private int lastYearTotal;

        // create List to include data for year up to current date
        private readonly List<DataModel> newModelData = new() { };

        // create List to include data for months from last year corresponding to current year i.e. if April include Jan - Apr only
        private readonly List<DataModel> oldModelData = new() { };

        // label xAxis based on current month need to include + 1 for the "Total" label       
        private readonly string[] xAxisItems = new string[DateTime.Now.Month + 1];

        // for populating column chart labels
        private readonly List<string> Months = new (){ "January", "February", "March", "April", "May",
                    "June", "July", "August", "September", "October", "November", "December"};

        public List<DataModel> GetDataForCurrentYear(int currentMonth)
        {
            // populate data model with month name and totals
            for (int i = 0; i < currentMonth; i++)
            {
                newModelData.Add(new DataModel()
                {
                    Month = Months[i],
                    Year = currentYear.ToString(),
                    MonthlyTotal = Treatments.Count(t => t.Date.Month == (i + 1))                   
                });

                // update running total
                currentYearTotal += newModelData[i].MonthlyTotal;
            }

            // add totals for column chart
            newModelData.Add(new DataModel()
            {
                Month = "Total",
                Year = currentYear.ToString(),
                MonthlyTotal = currentYearTotal
            });

            return newModelData;
        }


        protected List<DataModel> GetDataForLastYear(int currentMonth)
        {
            for (int i = 0; i < currentMonth; i++)
            {
                // populate data model with month name and totals
                oldModelData.Add(new DataModel()
                {
                    Month = Months[i],
                    Year = lastYear.ToString(),
                    MonthlyTotal = Treatments.Count(t => t.Date.Year == (DateTime.Now.Year - 1) && t.Date.Month == (i + 1))                    
                });

                // update running total
                lastYearTotal += oldModelData[i].MonthlyTotal;
            }

            // add totals for column chart
            oldModelData.Add(new DataModel()
            {
                Month = "Total",
                Year = lastYear.ToString(),
                MonthlyTotal = lastYearTotal
            }); 

            return newModelData;
        }


        public class DataModel
        {
            public int MonthlyTotal { get; set; }
            public string Month { get; set; }
            // included for label on chart
            public string Year { get; set; }
        }

        protected string[] GetDataForXAxis(int currentMonth)
        {
            for (int i = 0; i < currentMonth; i++)
            {
                xAxisItems[i] = Months[i];
            }

            // add total label
            xAxisItems[numItemsInXAxis -1] = "Total";

            return xAxisItems.ToArray();
        }       
    }
}

