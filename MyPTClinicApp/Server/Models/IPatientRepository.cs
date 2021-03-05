using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int patientId);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> AddPatient(Patient patient);
        void DeletePatient(int patientId);
    }
}

