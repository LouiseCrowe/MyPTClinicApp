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
        public SchedulerView CurrView { get; set; } = SchedulerView.Week;
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        DateTime DayStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        DateTime DayEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);

        List<SchedulerAppointment> Appointments { get; set; }

        async Task AddAppointment(SchedulerCreateEventArgs args)
        {
            SchedulerAppointment item = args.Item as SchedulerAppointment;

            //// perform actual data source operations here through your service
            //await MyService.Create(item);

            //// update the local view-model data with the service data
            //await GetSchedulerData();
        }


        async Task UpdateAppointment(SchedulerUpdateEventArgs args)
        {
            SchedulerAppointment item = (SchedulerAppointment)args.Item;

            //// perform actual data source operations here through your service
            //await MyService.Update(item);

            //// update the local view-model data with the service data
            //await GetSchedulerData();
        }

        
        async Task DeleteAppointment(SchedulerDeleteEventArgs args)
        {
            SchedulerAppointment item = (SchedulerAppointment)args.Item;

            //// perform actual data source operations here through your service
            //await MyService.Delete(item);

            //// update the local view-model data with the service data
            //await GetSchedulerData();

            // see the comments in the service mimic method below.
        }

        //Handlers for application logic flexibility
        void EditHandler(SchedulerEditEventArgs args)
        {
            SchedulerAppointment item = args.Item as SchedulerAppointment;
            if (!args.IsNew) // an edit operation, otherwise - an insert operation
            {
                // you can prevent opening an item for editing based on a condition
                if (item.Title.Contains("vet", StringComparison.InvariantCultureIgnoreCase))
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
