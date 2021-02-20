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
    [Route("api/therapist")]
    [ApiController]
    public class TherapistsController : ControllerBase
    {
        private readonly MyPTClinicAppServerContext _context;

        public TherapistsController(MyPTClinicAppServerContext context)
        {
            _context = context;
        }

        // GET: api/therapists
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Therapist>>> GetTherapist()
        {
            return await _context.Therapist.ToListAsync();
        }

        // GET: api/Therapists/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Therapist>> GetTherapist(int id)
        {
            var therapist = await _context.Therapist.FindAsync(id);

            if (therapist == null)
            {
                return NotFound();
            }

            return therapist;
        }

        // PUT: api/Therapists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTherapist(int id, Therapist therapist)
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
        [Produces("application/json")]
        public async Task<ActionResult<Therapist>> PostTherapist(Therapist therapist)
        {
            _context.Therapist.Add(therapist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTherapist", new { id = therapist.ID }, therapist);
        }

        // DELETE: api/Therapists/5
        [HttpDelete("{id}")]
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
