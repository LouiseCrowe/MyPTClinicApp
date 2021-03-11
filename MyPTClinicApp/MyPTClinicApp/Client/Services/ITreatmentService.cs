using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface ITreatmentService
    {   Task<IEnumerable<TreatmentDTO>> GetTreatments();
        Task<Treatment> GetTreatmentById(int id);
        Task<IEnumerable<Treatment>> GetTreatmentsByPatientId(int ID);
        Task<Treatment> AddTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task DeleteTreatment(int treatmentID);

    }
}
