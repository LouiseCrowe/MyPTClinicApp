using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface ITherapistService
    {
        Task<IEnumerable<Therapist>> GetTherapists();
        Task<IEnumerable<Therapist>> Search(string searchName);
        //Task<IEnumerable<Therapist>> SearchWithOneName(string name);
        //Task<IEnumerable<Therapist>> SearchWithTwoNames(string firstName, string lastName);
        Task<Therapist> GetTherapistById(int therapistID);
        Task<Therapist> AddTherapist(Therapist therapist);
        Task<Therapist> UpdateTherapist(Therapist therapist);
        Task<string> DeleteTherapist(int therapistID);      
    }
}
