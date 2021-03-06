using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Server.Models;
using MyPTClinicApp.Shared;

namespace MyPTClinicApp.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        // GET: api/patients/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            try
            {
                return Ok(await patientRepository.GetPatients());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retrieving data from the database");
            }

        }

        // GET: api/patients/id/2
        [HttpGet("id/{ID}", Name = "GetPatientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Patient>> GetPatientById([FromRoute] int id)
        {

            try
            {
                var result = await patientRepository.GetPatientById(id);

                if (result != null)
                {
                    return Ok(result);                    
                }
                else
                {
                    return NotFound($"Patient with ID {id} not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error retrieving data from the database");
            }
        }


        // GET: api/patients/therapistid/2
        [HttpGet("therapistid/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientByTherapistId(int id)
        {
            try
            {
                return Ok(await patientRepository.GetPatientsByTherapistId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }
        }

        // POST: api/patients 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest();
                }

                //// check for duplicate full name
                //var found = await patientRepository.GetPatientByFullName(patient.FirstName, patient.LastName);

                //if (found != null)
                //{
                //    ModelState.AddModelError("Full name", "Patient name already in use");
                //    return BadRequest(ModelState);
                //}

                var addedPatient = await patientRepository.AddPatient(patient);

                return CreatedAtAction("GetPatientById", 
                                        new { id = addedPatient.ID }, 
                                        addedPatient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error adding data");
            }
        }



        // PUT: api/patients/id/2
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, [FromBody] Patient patient)
        {
            try
            {
                if (id != patient.ID)
                {
                    return BadRequest("Patient ID mismatch");
                }

                // find patient to update
                var patientToUpdate = patientRepository.GetPatientById(id);

                if (patientToUpdate == null)
                {
                    return NotFound($"Patient with ID {id} not found");
                }

                return await patientRepository.UpdatePatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error updating data");
            }
        }

        

        //// DELETE: api/Patients/5
        //[HttpDelete("id/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> DeletePatient(int id)
        //{
        //    var patient = await _context.Patient.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Patient.Remove(patient);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PatientExists(int id)
        //{
        //    return _context.Patient.Any(e => e.ID == id);
        //}
    }
}
