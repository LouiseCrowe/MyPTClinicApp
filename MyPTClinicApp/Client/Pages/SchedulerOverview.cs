using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace MyPTClinicApp.Client.Pages
{
    public partial class SchedulerOverview
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        // displays full week on calendar (can also choose day, month, multi-day vew)
        public SchedulerView CurrView { get; set; } = SchedulerView.Week;   
        // determines what date displays on the calendar
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        // highlights start and end for working hours on calendar
        private readonly DateTime DayStartTime = new (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        private readonly DateTime DayEndTime = new (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);

        List<SchedulerAppointment> Appointments { get; set; }

        public SchedulerAppointment Appointment { get; set; } 

        // to include patient and therapist in appointment dropdowns
        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        // for selecting Therapist for appointment
        public List<String> Therapists { get; set; } = new List<String>();

        // for selecting Patient for appointment
        public List<String> Patients { get; set; } = new List<String>();
        
        protected override async Task OnInitializedAsync()
        {
            Appointments = (await AppointmentService.Read()).ToList();

            // for including therapist and patient in appointment
            Therapists = (await TherapistService.GetAllTherapistsFullNames()).ToList();
            Patients = (await PatientService.GetAllPatientsFullNames()).ToList();            
        }

        async Task AddAppointment(SchedulerCreateEventArgs args)
        {
            SchedulerAppointment item = args.Item as SchedulerAppointment;

            await AppointmentService.Create(item);

            Appointments = (await AppointmentService.Read()).ToList();           
        }

        async Task UpdateAppointment(SchedulerUpdateEventArgs args)
        {
            SchedulerAppointment item = (SchedulerAppointment)args.Item;

            await AppointmentService.Update(item);

            Appointments = (await AppointmentService.Read()).ToList();            
        }
        
        async Task DeleteAppointment(SchedulerDeleteEventArgs args)
        {
            SchedulerAppointment item = (SchedulerAppointment)args.Item;

            await AppointmentService.Delete(item);

            Appointments = (await AppointmentService.Read()).ToList();
        }

        //Handlers for application logic flexibility
        static void EditHandler(SchedulerEditEventArgs args)
        {
            // an edit operation, otherwise - an insert operation
            // you can prevent opening an item for editing based on a condition
            SchedulerAppointment item = args.Item as SchedulerAppointment;
            if (!args.IsNew && item.Title.Contains("do not edit", StringComparison.InvariantCultureIgnoreCase))
            {
                args.IsCancelled = true;
            }   
        }

    }
}
