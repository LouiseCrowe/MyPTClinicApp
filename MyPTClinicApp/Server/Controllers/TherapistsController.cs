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
    [Route("api/therapists")]
    [ApiController]
    public class TherapistsController : ControllerBase
    {
        private readonly MyPTClinicAppServerContext _context;

        public TherapistsController(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        // GET: api/therapists/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Therapist>>> GetTherapist()
        {
            return await _context.Therapist.OrderBy(t => t.ID).ToListAsync();
        }

        // GET: api/Therapists/id/2
        [HttpGet("id/{ID}", Name = "GetTherapistById")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Therapist> GetTherapistById([FromRoute] int id)
        {
            Therapist therapist = _context.Therapist.SingleOrDefault
                                            (t => t.ID == id);
            if (therapist == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(therapist);
            }
            
        }

        // PUT: api/Therapists/id/3
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTherapist([FromRoute] int id, 
                                                    [FromBody] Therapist therapist)
        {
            if (id != therapist.ID)
            {
                return BadRequest();
            }

            _context.Entry(therapist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TherapistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/therapists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Therapist>> PostTherapist(Therapist therapist)
        {
            _context.Therapist.Add(therapist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTherapistById", new { id = therapist.ID }, therapist);
        }

        // DELETE: api/Therapists/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTherapist(int id)
        {
            var therapist = await _context.Therapist.FindAsync(id);
            if (therapist == null)
            {
                return NotFound();
            }

            _context.Therapist.Remove(therapist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TherapistExists(int id)
        {
            return _context.Therapist.Any(e => e.ID == id);
        }
    }
}
