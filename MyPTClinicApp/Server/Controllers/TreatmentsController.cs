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
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly MyPTClinicAppServerContext _context;

        public TreatmentsController(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        // GET: api/treatments/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatment()
        {
            return await _context.Treatment.OrderBy(t => t.ID).ToListAsync();
        }

        // GET: api/treatments/id/2
        [HttpGet("id/{id}", Name = "GetTreatmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Treatment> GetTreatmentById([FromRoute] int id)
        {
            Treatment treatment = _context.Treatment.SingleOrDefault(t => t.ID == id);

            if (treatment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(treatment);
            }            
        }

        // PUT: api/treatments/id/2
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutUpdateTreatment([FromBody] Treatment treatment)
        {
            if (treatment != null)
            {
                // find therapist to update
                var treatmentToUpdate = _context.Treatment.FirstOrDefault(t => t.ID == treatment.ID);
                if (treatmentToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    treatmentToUpdate.PatientID = treatment.PatientID;
                    treatmentToUpdate.TherapistID = treatment.TherapistID;
                    treatmentToUpdate.Date = treatment.Date;
                    treatmentToUpdate.Notes = treatment.Notes;
                    
                    _context.SaveChanges();

                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Treatments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            _context.Treatment.Add(treatment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreatmentById", new { id = treatment.ID }, treatment);
        }

        // DELETE: api/Treatments/id/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment = await _context.Treatment.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _context.Treatment.Remove(treatment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatment.Any(e => e.ID == id);
        }
    }
}
