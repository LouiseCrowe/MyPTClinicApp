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
    public class TherapistsController : ControllerBase
    {

        private readonly ITherapistRepository therapistRepository;

        public TherapistsController(ITherapistRepository therapistRepository)
        {
            this.therapistRepository = therapistRepository;
        }

        // search criteria
        // GET: api/therapists/search
        [HttpGet("{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Therapist>>> Search(string searchName, string lastName)
        {
            try
            {
                var result = await therapistRepository.Search(searchName, lastName);

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


        //// search criteria
        //// GET: api/therapists/searchwithonename
        //[HttpGet("{searchwithonename}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<IEnumerable<Therapist>>> SearchWithOneName(string name)
        //{
        //    try
        //    {
        //        var result = await therapistRepository.SearchWithOneName(name);

        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}


        //// search criteria
        //// GET: api/therapists/searchtwonames
        //[HttpGet("{searchtwonames}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<IEnumerable<Therapist>>> SearchWithTwoNames(string firstName, string lastName)
        //{
        //    try
        //    {
        //        var result = await therapistRepository.SearchWithTwoNames(firstName, lastName);

        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }            
        //}


        // GET: api/therapists/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Therapist>>> GetAllTherapists()
        {
            try
            {
                return Ok(await therapistRepository.GetTherapists());
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        // GET: api/Therapists/id/2
        [HttpGet("id/{ID}", Name = "GetTherapistById")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Therapist>> GetTherapistById(int id)
        {
            try
            {
                var result = await therapistRepository.GetTherapistById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retrieving data from the database");
            }
        }

        // POST: api/therapists
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Therapist>> PostTherapist(Therapist therapist)
        {
            try
            {
                if (therapist == null)
                {
                    return BadRequest();
                }

                // check for duplicate full name
                var exists = await therapistRepository.GetTherapistByFullName(therapist.FirstName, therapist.LastName);

                if (exists != null)
                {
                   return BadRequest("Duplicate full name");
                }

                var addedTherapist = await therapistRepository.AddTherapist(therapist);

                return CreatedAtAction("GetTherapistById", 
                                        new { id = addedTherapist.ID }, 
                                        addedTherapist);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                   "Error adding data");
            }           
        }

        // PUT: api/Therapists/id/3
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Therapist>> UpdateTherapist(Therapist therapist)
        {
            try
            {
                if (therapist == null)
                {
                    return BadRequest();
                }

                // find therapist to update
                var therapistToUpdate = await therapistRepository.GetTherapistById(therapist.ID);

                if (therapistToUpdate == null)
                {
                    return NotFound($"Therapist with ID {therapist.ID} not found");
                }

                // check for duplicate name before updating, so if the full name matches but the ID is different
                // that means you're trying to update to a name that already is used in another therapist
                var existing = await therapistRepository.GetTherapistByFullName(therapist.FirstName, therapist.LastName);

                if ((existing != null) && (existing.ID != therapist.ID))
                {
                    return BadRequest("Duplicate full name");
                }

                return await therapistRepository.UpdateTherapist(therapist);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Therapists/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTherapist(int id)
        {
            try
            {
                var therapistToDelete = await therapistRepository.GetTherapistById(id);

                if (therapistToDelete == null)
                {
                    return NotFound($"Therapist with ID {id} not found");
                }

                await therapistRepository.DeleteTherapist(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error deleting data");
            }
        }
    }
}
