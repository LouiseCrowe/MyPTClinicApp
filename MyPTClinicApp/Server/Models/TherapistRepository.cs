using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class TherapistRepository : ITherapistRepository
    {
        // injecting DB context into repo
        private readonly ApplicationDbContext _context;

        public TherapistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Therapist>> Search(string searchName, string lastName)
        {
            // returns complete list of Therapists
            IQueryable<Therapist> query = _context.Therapist;

            if (!string.IsNullOrEmpty(searchName) && searchName == lastName)            // meaning only one name was provided              
            {
                query = query.Where(t => t.FirstName.ToLower().Contains(searchName.ToLower())
                                    || t.LastName.ToLower().Contains(searchName.ToLower()));
            }
            if (searchName != lastName)                             // meaning full name provided
            {
                query = query.Where(t => t.FirstName.ToLower().Contains(searchName.ToLower())
                                    && t.LastName.ToLower().Contains(lastName.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Therapist>> GetTherapists()
        {
            return await _context.Therapist.OrderBy(t => t.FirstName).ToListAsync();
        }

        public IEnumerable<String> GetAllTherapistsFullNames()
        {

            List<String> fullNames = new ();
            var query = _context.Therapist.OrderBy(t => t.FirstName)
                                            .Select(t => new { t.FirstName, t.LastName });

            foreach (var item in query)
            {
                fullNames.Add($"{item.FirstName} {item.LastName}");
            }

            return fullNames;

        }

        public async Task<Therapist> GetTherapistById(int therapistId)
        {
            return await _context.Therapist.FirstOrDefaultAsync(t => t.ID == therapistId);
        }

        public async Task<Therapist> GetTherapistByFullName(string firstName, string lastName)
        {
            return await _context.Therapist.FirstOrDefaultAsync(t => t.FirstName.ToLower() == firstName.ToLower()
                                                                && t.LastName.ToLower() == lastName.ToLower());
        }

        public async Task<Therapist> AddTherapist(Therapist therapist)
        {
            var result = await _context.Therapist.AddAsync(therapist);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Therapist> UpdateTherapist(Therapist therapist)
        {
            // find therapist to update
            var result = await _context.Therapist.FirstOrDefaultAsync(t => t.ID == therapist.ID);

            if (result != null)
            {
                result.FirstName = therapist.FirstName;
                result.LastName = therapist.LastName;
                result.Phone = therapist.Phone;
                result.Email = therapist.Email;
                result.Location = therapist.Location;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Therapist> DeleteTherapist(int therapistID)
        {
            var result = await _context.Therapist.FirstOrDefaultAsync(t => t.ID == therapistID);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
