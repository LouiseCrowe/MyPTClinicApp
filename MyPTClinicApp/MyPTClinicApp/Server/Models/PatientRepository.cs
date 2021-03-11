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
        private readonly MyPTClinicAppServerContext _context;

        public PatientRepository(MyPTClinicAppServerContext context)
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
            return await _context.Patient.FirstOrDefaultAsync(t => t.FirstName.ToLower() == firstName.ToLower()
                                                                && t.LastName.ToLower() == lastName.ToLower());
        }
    }
}
