using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface ITreatmentRepository
    {
        IQueryable<TreatmentDTO> GetTreatments();
        Task<IEnumerable<TreatmentDTO>> Search(string searchName, string lastName);
        Task<Treatment> GetTreatmentById(int treatmentId);
        IEnumerable<Treatment> GetTreatmentsByPatientId(int patientId);
        Task<Treatment> AddTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task<Treatment> DeleteTreatment(int treatmentId);

    }
}
