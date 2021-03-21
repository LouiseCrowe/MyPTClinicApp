using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IAppointmentService
    {
        Task<List<SchedulerAppointment>> Read();
        Task Create(SchedulerAppointment itemToInsert);
        Task Update(SchedulerAppointment itemToUpdate);
        Task Delete(SchedulerAppointment itemToDelete);
    }
}
