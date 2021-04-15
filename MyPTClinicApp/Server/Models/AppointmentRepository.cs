using Microsoft.EntityFrameworkCore;
using MyPTClinicApp.Server.Data;
using MyPTClinicApp.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ISendGridClient sendGridClient;
        private readonly HttpClient httpClient;
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context, ISendGridClient sendGridClient, HttpClient httpClient)
        {
            _context = context;
            this.sendGridClient = sendGridClient;
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<SchedulerAppointment>> GetAppointments()
        {
            return await _context.SchedulerAppointment.OrderByDescending(a => a.Start.Year)
                                                      .ThenByDescending(a => a.Start.Month)
                                                      .ThenByDescending(a => a.Start.Day)
                                                      .ThenBy(a => a.Start.Hour)
                                                      .ThenBy(a => a.Start.Minute)
                                                      .ToListAsync();
        }

        public async Task<SchedulerAppointment> GetAppointmentById(int appointmentId)
        {
            return await _context.SchedulerAppointment.FirstOrDefaultAsync(t => t.ID == appointmentId);
        }

        public async Task<IEnumerable<SchedulerAppointment>> GetAppointmentsByDate(DateTime appointmentsDate)
        {
            return await _context.SchedulerAppointment.Where(a => a.Start.Date == appointmentsDate.Date)
                                                      .OrderByDescending(a => a.Start.Year)
                                                      .ThenByDescending(a => a.Start.Month)
                                                      .ThenByDescending(a => a.Start.Day)
                                                      .ThenBy(a => a.Start.Hour)
                                                      .ThenBy(a => a.Start.Minute)
                                                      .ToListAsync();
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
                Date = appointment.Start,
                Notes = "Please update after treatment takes place"
            });

            await _context.Treatment.AddAsync(treatment);
            await _context.SaveChangesAsync();

            // send email confirming appointment
            string subject = $"Physical Therapy Appointment: {appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}";
            string content = $"Dear {patient.FirstName}" +
                             $"\n\nYour physical therapy appointment with {appointment.TherapistName} is confirmed for " +
                             $"{appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}." +
                             $"\n\nWe look forward to seeing you then." +
                             $"\n\nKind regards," +
                             $"\n\nDylan Crowe" +
                             $"\n\nPhone Number: 087 7774512" +
                             $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                             $"\nWebsite: https://dylancroweclinic.ie/";

            await SendEmail(patient, appointment, subject, content);

            return result.Entity;
        }

        public async Task SendEmail(Patient patient, SchedulerAppointment appointment, string subject, string content)
        {
            if (patient.Email != null)
            {
                SendGridMessage msg = new ();
                EmailAddress from = new ("dylan@dylancroweclinic.ie", "Dylan Crowe");
                EmailAddress recipient = new (patient.Email, $"{patient.FirstName} {patient.LastName}");

                msg.SetSubject(subject);
                msg.SetFrom(from);
                msg.AddTo(recipient);
                msg.PlainTextContent = content;

                await sendGridClient.SendEmailAsync(msg);
            }
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
                    treatment.Date = appointment.Start;

                    // send email confirming appointment
                    string subject = $"Appointment UPDATED: {appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}";
                    string content = $"Dear {patient.FirstName}" +
                             $"\n\nYour updated physical therapy appointment with {appointment.TherapistName} is confirmed for " +
                             $"{appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}." +
                             $"\n\nWe look forward to seeing you then." +
                             $"\n\nKind regards," +
                             $"\n\nDylan Crowe" +
                             $"\n\nPhone Number: 087 7774512" +
                             $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                             $"\nWebsite: https://dylancroweclinic.ie/";
                    await SendEmail(patient, appointment, subject, content);
                }

                await _context.SaveChangesAsync();                

                return result;
            }
            return null;
        }

            public async Task<SchedulerAppointment> DeleteAppointment(int appointmentId)
            {
                var appointmentToDelete = await _context.SchedulerAppointment.FirstOrDefaultAsync(a => a.ID == appointmentId);

                if (appointmentToDelete != null)
                {
                    _context.Remove(appointmentToDelete);

                // send email confirming appointment
                string subject = $"Appointment CANCELLED: {appointmentToDelete.Start.ToShortDateString()} at {appointmentToDelete.Start.ToShortTimeString()}";
                Patient patient = await FindPatientFromAppt(appointmentToDelete);
                string content = $"Dear {patient.FirstName}" +
                             $"\n\nYour physical therapy appointment with {appointmentToDelete.TherapistName} for " +
                             $"{appointmentToDelete.Start.ToShortDateString()} at {appointmentToDelete.Start.ToShortTimeString()} is cancelled." +
                             $"\n\nPlease call or text to re-book whenever you need our help again." +
                             $"\n\nKind regards," +
                             $"\n\nDylan Crowe" +
                             $"\n\nPhone Number: 087 7774512" +
                             $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                             $"\nWebsite: https://dylancroweclinic.ie/";
                await SendEmail(patient, appointmentToDelete, subject, content);

                // delete from treatments too
                var treatmentToDelete = _context.Treatment.FirstOrDefault(t => t.AppointmentID == appointmentId);
                    _context.Remove(treatmentToDelete);

                    await _context.SaveChangesAsync();
                    return appointmentToDelete;
                }
                return null;
            }

       
    }
    }

