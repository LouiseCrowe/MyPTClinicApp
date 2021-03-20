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
    public class SchedulerAppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public SchedulerAppointmentsController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        // GET: api/SchedulerAppointments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SchedulerAppointment>>> GetSchedulerAppointment()
        {
            try
            {
                return Ok(await appointmentRepository.GetAppointments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retrieving data from the database");
            }
        }

        // GET: api/SchedulerAppointments/5
        [HttpGet("{id}", Name = "GetAppointmentById")]
        public async Task<ActionResult<SchedulerAppointment>> GetAppointmentById(int id)
        {
            try
            {
                var result = await appointmentRepository.GetAppointmentById(id);

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

        // POST: api/SchedulerAppointments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SchedulerAppointment>> PostSchedulerAppointment(SchedulerAppointment schedulerAppointment)
        {
            try
            {
                //if (schedulerAppointment == null)
                //{
                //    return BadRequest();
                //}

                var addedAppointment = await appointmentRepository.AddAppointment(schedulerAppointment);

                return CreatedAtAction("GetAppointmentById",
                                        new { id = addedAppointment.ID },
                                        addedAppointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error adding data");
            }
        }


        // PUT: api/SchedulerAppointments/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SchedulerAppointment>> UpdateAppointment(SchedulerAppointment schedulerAppointment)
        {
            try
            {
                if (schedulerAppointment == null)
                {
                    return BadRequest();
                }

                // find appointment to update
                var appointmentToUpdate = await appointmentRepository.GetAppointmentById(schedulerAppointment.ID);

                if (appointmentToUpdate == null)
                {
                    return NotFound($"Appointment with ID {schedulerAppointment.ID} not found");
                }

                return await appointmentRepository.UpdateAppointment(schedulerAppointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/SchedulerAppointments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteSchedulerAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await appointmentRepository.GetAppointmentById(id);

                if (appointmentToDelete == null)
                {
                    return NotFound($"Appointment with ID {id} not found");
                }

                await appointmentRepository.DeleteAppointment(id);

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
