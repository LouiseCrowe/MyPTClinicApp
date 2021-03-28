using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SchedulerAppointment>> GetAppointments()
        {
            return await _context.SchedulerAppointment.ToListAsync();
        }

        public async Task<SchedulerAppointment> GetAppointmentById(int appointmentId)
        {
            return await _context.SchedulerAppointment.FirstOrDefaultAsync(t => t.ID == appointmentId);
        }

        public async Task<SchedulerAppointment> AddAppointment(SchedulerAppointment appointment)
        {
            var result = await _context.SchedulerAppointment.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SchedulerAppointment> UpdateAppointment(SchedulerAppointment appointment)
        {
            // find therapist to update
            var result = await _context.SchedulerAppointment.FirstOrDefaultAsync(a => a.ID == appointment.ID);

            if (result != null)
            {
                result.Title = appointment.Title;
                result.Description = appointment.Description;
                result.Start = appointment.Start;
                result.End = appointment.End;
                result.IsAllDay = appointment.IsAllDay;
                result.RecurrenceId = appointment.RecurrenceId;
                result.RecurrenceRule = appointment.RecurrenceRule;
                result.TherapistName = appointment.TherapistName;
                result.PatientName = appointment.PatientName;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<SchedulerAppointment> DeleteAppointment(int appointmentId)
        {
            var result = await _context.SchedulerAppointment.FirstOrDefaultAsync(a => a.ID == appointmentId);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
