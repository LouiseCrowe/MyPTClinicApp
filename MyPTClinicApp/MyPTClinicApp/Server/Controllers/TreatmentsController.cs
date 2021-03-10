﻿using System;
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
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentRepository treatmentRepository;

        public TreatmentsController(ITreatmentRepository treatmentRepository)
        {
            this.treatmentRepository = treatmentRepository;
        }

        // GET: api/treatments/all
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<TreatmentDTO> GetTreatments()
        {
            return treatmentRepository.GetTreatments();
        }



        // GET: api/treatments/id/2
        [HttpGet("id/{id}", Name = "GetTreatmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Treatment>> GetTreatmentById([FromRoute] int id)
        {
            try
            {
                var result = await treatmentRepository.GetTreatmentById(id);

                if (result == null)
                {
                    return NotFound($"Treatment with id {id} not found");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retrieving data from the database");
            }
        }

        // POST: api/Treatments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            try
            {
                if (treatment == null)
                {
                    return BadRequest();
                }
                                
                var addedTreatment = await treatmentRepository.AddTreatment(treatment);

                return CreatedAtAction("GetTreatmentById",
                                        new { id = addedTreatment.ID }, 
                                        addedTreatment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error adding data");
            }
        }

        // PUT: api/treatments/id/2
        [HttpPut("id/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Treatment>> PutUpdateTreatment(int id, [FromBody] Treatment treatment)
        {
            try
            {
                if (id != treatment.ID)
                {
                    return BadRequest("Treatment ID mismatch");
                }

                // find treatment to update
                var treatmentToUpdate = await treatmentRepository.GetTreatmentById(id);

                if (treatmentToUpdate == null)
                {
                    return NotFound($"Treatment with ID {id} not found");
                }

                return await treatmentRepository.UpdateTreatment(treatment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error updating data");
            }

        }

        // DELETE: api/Treatments/id/5
        [HttpDelete("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Treatment>> DeleteTreatment(int id)
        {
            try
            {
                // find treatment to delete
                var treatmentToDelete = await treatmentRepository.GetTreatmentById(id);

                if (treatmentToDelete == null)
                {
                    return NotFound($"Treatment with ID {id} not found");
                }

                return await treatmentRepository.DeleteTreatment(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error deleting data");
            }
        }

        //private bool TreatmentExists(int id)
        //{
        //    return _context.Treatment.Any(e => e.ID == id);
        //}
    }
}
