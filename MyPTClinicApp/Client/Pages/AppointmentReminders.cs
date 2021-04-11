using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class AppointmentReminders
    {
        [Inject]
        public ITreatmentService TreatmentService { get; set; }

        private IEnumerable<TreatmentDTO> Treatments { get; set; }

        // default to the next day, can be manually changed for weekend
        public DateTime AppointmentsDate { get; set; } = DateTime.Now.AddDays(1.0);         


        protected override async Task OnInitializedAsync()
        {
            Treatments = await TreatmentService.GetTreatments();        // retrieves all treatments                
        }

        public async Task GetAppointments()
        { 
        
        }
    }
}
