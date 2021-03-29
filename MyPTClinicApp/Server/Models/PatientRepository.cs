using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class PatientRepository : IPatientRepository
    {
        // injecting DB context into repo
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Patient.OrderBy(p => p.ID).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.ID == patientId);
        }

        public async Task<IEnumerable<Patient>> Search(string searchName, string lastName)
        {
            // returns complete list of Patients
            IQueryable<Patient> query = _context.Patient;

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

        public IEnumerable<String> GetAllPatientsFullNames()
        {

            List<String> fullNames = new List<string>();
            var query = _context.Patient.OrderBy(p => p.FirstName).Select(p => new { p.FirstName, p.LastName });

            foreach (var item in query)
            {
                fullNames.Add($"{item.FirstName} {item.LastName}");
            }

            return fullNames;

        }
        public IEnumerable<Patient> GetPatientsByTherapistId(int therapistId)
        {
            // look for patients
            var results = _context.Patient.Where(p => p.TherapistID == therapistId).ToList();

            return results;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var result = await _context.Patient.AddAsync(patient);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Patient> UpdatePatient(Patient patient)
        {
            // find patient to update
            var result = await _context.Patient.FirstOrDefaultAsync(p => p.ID == patient.ID);

            if (result != null)
            {
                result.FirstName = patient.FirstName;
                result.LastName = patient.LastName;
                result.DateOfBirth = patient.DateOfBirth;
                result.Gender = patient.Gender;
                result.Phone = patient.Phone;
                result.Email = patient.Email;
                result.Address = patient.Address;
                result.Medications = patient.Medications;
                result.TherapistID = patient.TherapistID;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Patient> DeletePatient(int patientId)
        {
            var result = await _context.Patient.FirstOrDefaultAsync(p => p.ID == patientId);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null; 
        }

        public async Task<Patient> GetPatientByFullName(string firstName, string lastName)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.FirstName.ToLower() == firstName.ToLower()
                                                                && p.LastName.ToLower() == lastName.ToLower());
        }
    }
}
