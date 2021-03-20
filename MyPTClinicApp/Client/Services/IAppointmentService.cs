using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<SchedulerAppointment>> GetAppointments();
        Task<IEnumerable<SchedulerAppointment>> GetAppointmentById();
        Task<SchedulerAppointment> AddAppointment(SchedulerAppointment appointment);
        Task<SchedulerAppointment> UpdateAppointment(SchedulerAppointment appointment);
        Task DeleteAppointment(int appointmentID);
    }
}
