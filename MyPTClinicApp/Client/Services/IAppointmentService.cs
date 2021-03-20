using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int appointmentID);
    }
}
