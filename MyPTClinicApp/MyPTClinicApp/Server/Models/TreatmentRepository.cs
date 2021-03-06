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

        public async Task<IEnumerable<Treatment>> GetTreatments()
        {
            return await _context.Treatment.OrderBy(t => t.ID).ToListAsync();
        }


        public async Task<Treatment> GetTreatmentById(int treatmentId)
        {
            return await _context.Treatment.FirstOrDefaultAsync(t => t.ID == treatmentId);
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

        public async void DeleteTreatment(int treatmentId)
        {
            // find treatment to delete
            var result = await _context.Treatment.FirstOrDefaultAsync(t => t.ID == treatmentId);

            if (result != null)
            {
                _context.Treatment.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
