using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<SchedulerAppointment>> GetAppointments();
        Task<SchedulerAppointment> GetAppointmentById(int appointmentId);
        Task<IEnumerable<SchedulerAppointment>> GetAppointmentsByDate(DateTime appointmentsDate);
        Task<SchedulerAppointment> UpdateAppointment(SchedulerAppointment appointment);
        Task<SchedulerAppointment> AddAppointment(SchedulerAppointment appointment);
        Task<SchedulerAppointment> DeleteAppointment(int appointmentId);
    }
}
