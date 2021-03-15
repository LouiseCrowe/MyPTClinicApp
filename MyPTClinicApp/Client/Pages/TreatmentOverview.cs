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
               
        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();
        }

    }
}