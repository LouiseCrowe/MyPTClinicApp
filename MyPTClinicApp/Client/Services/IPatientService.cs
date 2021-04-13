using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> Search(string searchName, string lastName);
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<String>> GetAllPatientsFullNames();
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatientsByTherapistId(int ID);
        Task<PatientDTO> GetPatientNameAndEmail(string firstName, string lastName);
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> UpdatePatient(Patient patient);
        Task DeletePatient(int patientID);
    }
}
