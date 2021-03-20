using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public class AppointmentService : IAppointmentService
    {
        public Task<Appointment> AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAppointment(int appointmentID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
