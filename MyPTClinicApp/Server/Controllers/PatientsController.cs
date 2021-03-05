using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;

namespace MyPTClinicApp.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly MyPTClinicAppServerContext _context;

        public PatientsController(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        // GET: api/patients/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            return await _context.Patient.OrderBy(p => p.ID).ToListAsync();
        }

        // GET: api/patients/id/2
        [HttpGet("id/{ID}", Name = "GetPatientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Patient>> GetPatientById([FromRoute] int id)
        {
            Patient patient = await _context.Patient.FirstOrDefaultAsync(p => p.ID == id);
                              

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patient);
            }
        }

        // GET: api/patients/therapistid/2
        [HttpGet("therapistid/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientByTherapistId([FromRoute] int id)
        {
            var patients = await _context.Patient.Where(p => p.TherapistID == id).ToListAsync();

            if (patients != null)
            {
                return Ok(patients);
            }
            else
            {
                return NotFound();
            }
        }


        // PUT: api/patients/id/2
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Patient>> UpdatePatient([FromBody] Patient patient)
        {
            if (patient != null)
            {
                // find therapist to update and confirm that Therapist ID is valid
                var patientToUpdate = await _context.Patient.FirstOrDefaultAsync(t => t.ID == patient.ID);
                if (patientToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    patientToUpdate.FirstName = patient.FirstName;
                    patientToUpdate.LastName = patient.LastName;
                    patientToUpdate.Phone = patient.Phone;
                    patientToUpdate.Email = patient.Email;
                    patientToUpdate.Address = patient.Address;
                    patientToUpdate.DateOfBirth = patient.DateOfBirth;
                    patientToUpdate.Medications = patient.Medications;
                    patientToUpdate.Gender = patient.Gender;
                    patientToUpdate.TherapistID = patient.TherapistID;

                    _context.SaveChanges();

                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }
     
        // POST: api/patients 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientById", new { id = patient.ID }, patient);
        }


        // DELETE: api/Patients/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.ID == id);
        }
    }
}
