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

        public SchedulerView CurrView { get; set; } = SchedulerView.Week;
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        DateTime DayStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        DateTime DayEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);

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
        void EditHandler(SchedulerEditEventArgs args)
        {
            SchedulerAppointment item = args.Item as SchedulerAppointment;
            if (!args.IsNew) // an edit operation, otherwise - an insert operation
            {
                // you can prevent opening an item for editing based on a condition
                if (item.Title.Contains("do not edit", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.IsCancelled = true;
                }
            }
            else
            {
                // new appointment
                DateTime SlotStart = args.Start; // the start of the slot the user clicked
                DateTime SlotEnd = args.End; // the start of the slot the user clicked
                bool InsertInAllDay = args.IsAllDay; // whether the user started insertion in the All Day row
            }
        }

        void CancelHandler(SchedulerCancelEventArgs args)
        {
            // you can know when a user wanted to modify an appointment but decided not to
            // the model you get contains the new data from the edit form so you can see what they did
            SchedulerAppointment item = args.Item as SchedulerAppointment;
        }



    }
}
