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
        Task<Therapist> GetTherapistById(int therapistID);
        Task<Therapist> AddTherapist(Therapist therapist);
        Task<Therapist> UpdateTherapist(Therapist therapist);
        Task DeleteTherapist(int therapistID);        
    }
}
