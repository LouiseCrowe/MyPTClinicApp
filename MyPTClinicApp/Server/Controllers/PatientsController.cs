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
    [Route("api/[controller]")]
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

        // GET: api/patients/fullnames
        [HttpGet("fullnames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<String>> GetAllPatientsFullNames()
        {
            try
            {
                return Ok(patientRepository.GetAllPatientsFullNames());
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
        public async Task<ActionResult<Patient>> GetPatientById(int id)
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

        // search criteria
        // GET: api/patients/search
        [HttpGet("{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Patient>>> Search(string searchName, string lastName)
        {
            try
            {
                var result = await patientRepository.Search(searchName, lastName);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
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
        public ActionResult<IEnumerable<Patient>> GetPatientByTherapistId(int id)
        {
            try
            {
                return Ok(patientRepository.GetPatientsByTherapistId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }
        }


        // GET: api/patients/nameandemail/firstName/lastName
        [HttpGet("nameandemail/{firstName}/{lastName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PatientDTO> GetPatientNameAndEmail(string firstName, string lastName)
        {
            try
            {
                return Ok(patientRepository.GetPatientNameAndEmail(firstName, lastName));
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

                // check for duplicate full name - need to handle in Client side
                Patient exists = await patientRepository.GetPatientByFullName(patient.FirstName, patient.LastName);

                if (exists != null)
                {
                    return BadRequest("Duplicate full name");
                }

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
        public async Task<ActionResult<Patient>> UpdatePatient(Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest();
                }

                // find patient to update
                var patientToUpdate = await patientRepository.GetPatientById(patient.ID);

                if (patientToUpdate == null)
                {
                    return NotFound($"Patient with ID {patient.ID} not found");
                }

                // check for duplicate name before updating, so if the full name matches but the ID is different
                // that means you're trying to update to a name that already is used in another patient
                var existing = await patientRepository.GetPatientByFullName(patient.FirstName, patient.LastName);

                if (existing != null && existing.ID != patient.ID)
                {
                    return BadRequest("Duplicate full name");
                }

                return await patientRepository.UpdatePatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error updating data");
            }
        }


        // DELETE: api/Patients/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            try
            {
                var patientToDelete = await patientRepository.GetPatientById(id);

                if (patientToDelete == null)
                {
                    return NotFound($"Patient with id {id} not found");                    
                }

                return await patientRepository.DeletePatient(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error deleting data");
            }
        }
    }
}
