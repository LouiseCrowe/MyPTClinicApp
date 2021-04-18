using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface ITreatmentService
    {   
        Task<IEnumerable<TreatmentDto>> GetTreatments();
        Task<IEnumerable<TreatmentDto>> Search(string searchName, string lastName, DateTime fromDate, DateTime toDate);
        Task<Treatment> GetTreatmentById(int id);
        Task<IEnumerable<Treatment>> GetTreatmentsByDate(int year, int month, int day);
        Task<IEnumerable<Treatment>> GetTreatmentsByPatientId(int ID);
        Task<Treatment> AddTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task DeleteTreatment(int treatmentID);
    }
}
