using MyPTClinicApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IAppointmentService
    {
        Task<List<SchedulerAppointment>> Read();
        Task<List<SchedulerAppointment>> GetAppointmentsByDate(int year, int month, int day);        
        Task Create(SchedulerAppointment itemToInsert);
        Task Update(SchedulerAppointment itemToUpdate);
        Task Delete(SchedulerAppointment itemToDelete);
    }
}
