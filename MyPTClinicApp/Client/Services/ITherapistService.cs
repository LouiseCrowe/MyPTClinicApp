using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface ITherapistService
    {
        Task<IEnumerable<Therapist>> GetTherapists();
        Task<IEnumerable<Therapist>> Search(string searchName, string lastName);
        Task<IEnumerable<String>> GetAllTherapistsFullNames();
        Task<Therapist> GetTherapistById(int therapistID);
        Task<Therapist> AddTherapist(Therapist therapist);
        Task<Therapist> UpdateTherapist(Therapist therapist);
        Task<string> DeleteTherapist(int therapistID);      
    }
}
