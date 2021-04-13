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
        Task<Patient> GetPatientByFullName(string firstName, string lastName);
        PatientDTO GetPatientNameAndEmail(string firstName, string lastName);
        Task<IEnumerable<Patient>> Search(string searchName, string lastName);
        IEnumerable<String> GetAllPatientsFullNames();
        IEnumerable<Patient> GetPatientsByTherapistId(int therapistId);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> DeletePatient(int patientId);
    }
}

