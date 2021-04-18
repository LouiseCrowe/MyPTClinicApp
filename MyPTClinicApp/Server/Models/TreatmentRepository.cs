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
        public ApplicationDbContext DbContext { get; }

        public TreatmentRepository(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public async Task<Treatment> AddTreatment(Treatment treatment)
        {
            var result = await DbContext.Treatment.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<TreatmentDTO> GetTreatments()
        {
            var treatments = from t in DbContext.Treatment.OrderByDescending(t => t.Date.Year)
                                                         .ThenByDescending(t => t.Date.Month)
                                                         .ThenByDescending(t => t.Date.Day)
                                                         .ThenBy(t => t.Date.Hour)
                                                         .ThenBy(t => t.Date.Minute)
                                                         .ThenBy(t => t.Therapist.FirstName)
                             select new TreatmentDTO()
                             {
                                 ID = t.ID,
                                 PatientId = t.Patient.ID,
                                 PatientFirstName = t.Patient.FirstName,
                                 PatientLastName = t.Patient.LastName,
                                 TherapistId = t.Therapist.ID,
                                 TherapistFirstName = t.Therapist.FirstName,
                                 TherapistLastName = t.Therapist.LastName,
                                 Date = t.Date,
                                 Notes = t.Notes
                             };
            return treatments;
        }


        public async Task<IEnumerable<TreatmentDTO>> Search(string searchName, string lastName, DateTime fromDate, DateTime toDate)
        {
            // get full list of treatments that match date
            var query = GetTreatments().Where(t => t.Date >= fromDate && t.Date <= toDate);

            if (searchName == "" && lastName == "")
            {
                return await query.ToListAsync();
            }

            //  look for search name if one is provided
            if (!string.IsNullOrEmpty(searchName) && searchName == lastName)            // meaning only one name was provided              
            {
                query = query.Where(t => t.PatientFirstName.ToLower().Contains(searchName.ToLower())
                                    || t.PatientLastName.ToLower().Contains(searchName.ToLower())
                                    || t.TherapistFirstName.ToLower().Contains(searchName.ToLower())
                                    || t.TherapistLastName.ToLower().Contains(searchName.ToLower()));

            }
            if (searchName != lastName)                             // meaning full name provided
            {
                query = query.Where(t => (t.PatientFirstName.ToLower().Contains(searchName.ToLower())
                                    && t.PatientLastName.ToLower().Contains(lastName.ToLower()))
                                    || (t.TherapistFirstName.ToLower().Contains(searchName.ToLower())
                                    && t.TherapistLastName.ToLower().Contains(lastName.ToLower())));
            }

            return await query.ToListAsync();
        }

        public async Task<Treatment> GetTreatmentById(int treatmentId)
        {
            return await DbContext.Treatment.FirstOrDefaultAsync(p => p.ID == treatmentId);
        }

        public IEnumerable<Treatment> GetTreatmentsByPatientId(int patientId)
        {
            return DbContext.Treatment.Where(t => t.PatientID == patientId).OrderByDescending(t => t.Date);
        }


        public async Task<IEnumerable<Treatment>> GetTreatmentsByDate(DateTime appointmentsDate)
        {
            return await DbContext.Treatment.Where(t => t.Date == appointmentsDate)
                                                      .OrderByDescending(t => t.Date.Year)
                                                      .ThenByDescending(t => t.Date.Month)
                                                      .ThenByDescending(t => t.Date.Day)
                                                      .ThenBy(t => t.Date.Hour)
                                                      .ThenBy(t => t.Date.Minute)
                                                      .ToListAsync();
        }

        public async Task<Treatment> UpdateTreatment(Treatment treatment)
        {
            // find treatment to update
            var result = await DbContext.Treatment.FirstOrDefaultAsync(t => t.ID == treatment.ID);

            if (result != null)
            {
                result.PatientID = treatment.PatientID;
                result.TherapistID = treatment.TherapistID;
                result.Date = treatment.Date;
                result.Notes = treatment.Notes;

                await DbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Treatment> DeleteTreatment(int treatmentId)
        {
            // find treatment to delete
            var treatmentToDelete = await DbContext.Treatment.FirstOrDefaultAsync(t => t.ID == treatmentId);

            if (treatmentToDelete != null)
            {
                DbContext.Treatment.Remove(treatmentToDelete);
                await DbContext.SaveChangesAsync();
                return treatmentToDelete;
            }

            return null;
        }
    }
}
