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
        private readonly MyPTClinicAppServerContext _context;

        public TherapistRepository(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Therapist>> Search(string firstName)
        {
            // returns complete list of Therapists
            IQueryable<Therapist> query = _context.Therapist;

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(t => t.FirstName.ToLower().Contains(firstName.ToLower()));
            }

            return await query.ToListAsync();
        }

        //public async Task<IEnumerable<Therapist>> SearchWithOneName(string name)
        //{
        //    // returns complete list of Therapists
        //    IQueryable<Therapist> query = _context.Therapist;

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(t => t.FirstName.ToLower().Contains(name.ToLower())
        //                            || t.LastName.ToLower().Contains(name.ToLower()));
        //    }

        //    return await query.ToListAsync();
        //}


        //public async Task<IEnumerable<Therapist>> SearchWithTwoNames(string firstName, string lastName)
        //{
        //    // returns complete list of Therapists
        //    IQueryable<Therapist> query = _context.Therapist;

        //    if (!string.IsNullOrEmpty(firstName))
        //    {
        //        query = query.Where(t => t.FirstName.ToLower().Contains(firstName.ToLower())
        //                            && t.LastName.ToLower().Contains(lastName.ToLower()));
        //    }

        //    return await query.ToListAsync();
        //}


        public async Task<IEnumerable<Therapist>> GetTherapists()
        {
            return await _context.Therapist.OrderBy(t => t.ID).ToListAsync();
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
            var result = await _context.Therapist.FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Therapist, bool>>)(t => t.ID == therapist.ID));

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
        
        public async Task<Therapist> DeleteTherapist(int therapistId)
        {
            var result = await _context.Therapist.FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Therapist, bool>>)(t => t.ID == therapistId));

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
