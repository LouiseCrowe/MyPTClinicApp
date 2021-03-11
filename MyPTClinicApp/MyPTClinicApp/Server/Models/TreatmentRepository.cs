using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class TreatmentRepository : ITreatmentRepository
    {
        public MyPTClinicAppServerContext _context { get; }

        public TreatmentRepository(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        public async Task<Treatment> AddTreatment(Treatment treatment)
        {
            var result = await _context.Treatment.AddAsync(treatment);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<TreatmentDTO> GetTreatments()
        {
            var treatments = from t in _context.Treatment.OrderByDescending(t => t.Date)
                             select new TreatmentDTO()
                             {
                                 ID = t.ID,
                                 PatientFirstName = t.Patient.FirstName,
                                 PatientLastName = t.Patient.LastName,
                                 TherapistFirstName = t.Therapist.FirstName,
                                 TherapistLastName = t.Therapist.LastName,
                                 Date = t.Date,
                                 Notes = t.Notes
                             };
            return treatments;

            //return await _context.Treatment.OrderBy(t => t.ID).ToListAsync();
        }


        public async Task<Treatment> GetTreatmentById(int treatmentId)
        {
            return await _context.Treatment.FirstOrDefaultAsync(p => p.ID == treatmentId);
        }

        public async Task<Treatment> UpdateTreatment(Treatment treatment)
        {
            // find treatment to update
            var result = await _context.Treatment.FirstOrDefaultAsync(t => t.ID == treatment.ID);

            if (result != null)
            {
                result.PatientID = treatment.PatientID;
                result.TherapistID = treatment.TherapistID;
                result.Date = treatment.Date;
                result.Notes = treatment.Notes;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Treatment> DeleteTreatment(int treatmentId)
        {
            // find treatment to delete
            var treatmentToDelete = await _context.Treatment.FirstOrDefaultAsync(t => t.ID == treatmentId);

            if (treatmentToDelete != null)
            {
                _context.Treatment.Remove(treatmentToDelete);
                await _context.SaveChangesAsync();
                return treatmentToDelete;
            }

            return null;
        }
    }
}
