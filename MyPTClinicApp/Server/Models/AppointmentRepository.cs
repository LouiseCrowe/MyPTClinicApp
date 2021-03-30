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

            // if user selects a patient, therapist or both patient and therapist when adding an appointment a 
            // skeleton treatment will be added which will be manually updated after the treatment is completed
            // declare variables for updating treatment

            Patient patient = new();
            Therapist therapist = new();

            // patient and therapist included in appointment
            if (!String.IsNullOrEmpty(appointment.PatientName) && !String.IsNullOrEmpty(appointment.TherapistName))
            {
                patient = await FindPatientFromAppt(appointment);
                therapist = await FindTherapistFromAppt(appointment);
            }

            // therapist included in appointment but therapist is left blank
            if (String.IsNullOrEmpty(appointment.PatientName))
            {
                var query = await _context.Patient.FirstOrDefaultAsync(p => p.FirstName == "To"
                                            && p.LastName == "Be Confirmed");
                patient = query;
                therapist = await FindTherapistFromAppt(appointment);

            }
            if (String.IsNullOrEmpty(appointment.TherapistName))
            {
                var query = await _context.Therapist.FirstOrDefaultAsync(t => t.FirstName == "To"
                                           && t.LastName == "Be Confirmed");
                therapist = query;
                patient = await FindPatientFromAppt(appointment);
            }

            // create treatment and add to database
            Treatment treatment = (new Treatment
            {
                PatientID = patient.ID,
                TherapistID = therapist.ID,
                AppointmentID = appointment.ID,
                Date = appointment.Start.Date,
                Notes = "Please update after treatment takes place"
            });

            await _context.Treatment.AddAsync(treatment);
            await _context.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Patient> FindPatientFromAppt(SchedulerAppointment appointment)
        {
            // find patient to include in treatment based on name in appointment
            string patientFirstName, patientLastName;

            string[] patientFullName = appointment.PatientName.Split(" ");
            patientFirstName = patientFullName[0];
            if (patientFullName.Length > 1)
            {
                patientLastName = patientFullName[^1];
            }
            else
            {
                patientLastName = patientFullName[0];
            }

            return await _context.Patient.FirstOrDefaultAsync
                                        (p => p.FirstName.ToLower().Contains(patientFirstName.ToLower())
                                        && p.LastName.ToLower().Contains(patientLastName.ToLower()));
        }


        public async Task<Therapist> FindTherapistFromAppt(SchedulerAppointment appointment)
        {
            // find therapist to include in treatment based on name in appointment
            string therapistFirstName, therapistLastName;

            string[] therapistFullName = appointment.TherapistName.Split(" ");
            therapistFirstName = therapistFullName[0];
            if (therapistFullName.Length > 1)
            {
                therapistLastName = therapistFullName[^1];
            }
            else
            {
                therapistLastName = therapistFullName[0];
            }

            return await _context.Therapist.FirstOrDefaultAsync
                                         (t => t.FirstName.ToLower().Contains(therapistFirstName.ToLower())
                                         && t.LastName.ToLower().Contains(therapistLastName.ToLower()));
        }

        public async Task<SchedulerAppointment> UpdateAppointment(SchedulerAppointment appointment)
        {
            // find schedulerAppointment to update
            var result = await _context.SchedulerAppointment.FirstOrDefaultAsync(a => a.ID == appointment.ID);

            if (result != null)
            {
                // update appointment
                result.Title = appointment.Title;
                result.Description = appointment.Description;
                result.Start = appointment.Start;
                result.End = appointment.End;
                result.IsAllDay = appointment.IsAllDay;
                result.RecurrenceId = appointment.RecurrenceId;
                result.RecurrenceRule = appointment.RecurrenceRule;
                result.TherapistName = appointment.TherapistName;
                result.PatientName = appointment.PatientName;
              

                // find related treatment to update too.
                var treatment = _context.Treatment.FirstOrDefault(t => t.AppointmentID == appointment.ID);
                if (treatment != null)
                {
                    // find patient and therapist included in appointment
                    Patient patient = await FindPatientFromAppt(appointment);
                    Therapist therapist = await FindTherapistFromAppt(appointment);
                    // update treatment 
                    treatment.PatientID = patient.ID;
                    treatment.TherapistID = therapist.ID;
                    treatment.Date = appointment.Start.Date;
                    
                }


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

                    // delete from treatments too
                    var treatmentToDelete = _context.Treatment.FirstOrDefault(t => t.AppointmentID == appointmentId);
                    _context.Remove(treatmentToDelete);

                    await _context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
        }
    }

