using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatientsByTherapistId(int ID);
    }
}
