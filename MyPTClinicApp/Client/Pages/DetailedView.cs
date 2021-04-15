using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class DetailedView
    {
        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        private IEnumerable<TreatmentDTO> Treatments { get; set; }
       

        // Calling back all treatments to populate detailed grid
        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments 
        }
    }
}
