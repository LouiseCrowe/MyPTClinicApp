using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface ITherapistRepository
    {
        Task<IEnumerable<Therapist>> GetTherapists();
        Task<Therapist> GetTherapistById(int therapistId);
        Task<Therapist> UpdateTherapist(Therapist therapist);
        Task<Therapist> AddTherapist(Therapist therapist);
        void DeleteTherapist(int therapistId);
    }
}
