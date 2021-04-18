using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class AppointmentReminders
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        // set default date to the next day
        public DateTime AppointmentsDate { get; set; } = DateTime.Now.AddDays(1);

        // for retrieving list of appointments for specified date
        public List<SchedulerAppointment> Appointments { get; set; } = new();

        // for retrieving patient email address
        public PatientDTO Patient { get; set; } = new();

        // list for displaying names of patients whe were or were not sent emails
        protected List<string> emailRecipients = new();
        protected List<string> noEmailList = new();

        // for managing screen messages regarding sending emails
        protected string SuccessStatusClass = string.Empty;
        protected StringBuilder successMessage = new();
        protected string noEmailStatusClass = string.Empty;
        protected StringBuilder noEmailMessage = new();
        protected string sendingStatusClass = string.Empty;
        protected string sendingMessage = string.Empty;

        

        protected override async Task OnInitializedAsync()
        {
            // initial rendering will display the appointments for the following day
            Appointments = await AppointmentService.GetAppointmentsByDate(AppointmentsDate.Year, AppointmentsDate.Month, AppointmentsDate.Day);
        }

        public async Task GetAppointments()
        {
            Appointments = await AppointmentService.GetAppointmentsByDate(AppointmentsDate.Year, AppointmentsDate.Month, AppointmentsDate.Day);

            // need to check that appointment time has not passed for current date appointments
            // don't want to send reminders for an appointment time in the past
            if (AppointmentsDate.Year == DateTime.Now.Year
                && AppointmentsDate.Month == DateTime.Now.Month
                && AppointmentsDate.Day == DateTime.Now.Day)
            {
                Appointments = Appointments.Where(a => a.Start.TimeOfDay >= DateTime.Now.TimeOfDay).ToList();                
            }
            
            // clear all messages from screen when new search is completed
            SuccessStatusClass = string.Empty;
            successMessage = new();
            noEmailStatusClass = string.Empty;
            noEmailMessage = new();
            sendingStatusClass = string.Empty;
            sendingMessage = string.Empty;
            emailRecipients = new();
            noEmailList = new();
        }

        
        protected async Task SendReminderMails()
        {
            // reminders can only be sent for appointments between current day and the following five days
            if (AppointmentsDate.AddDays(1) >= DateTime.Now  && AppointmentsDate <= DateTime.Now.AddDays(5) && Appointments.Count >= 1)
            {
                foreach (SchedulerAppointment appointment in Appointments)
                {
                    if (appointment.PatientName != "" || appointment.PatientName != "To Be Confirmed")
                    {
                        // find patient email based on patient name in appointment
                        string patientFirstName, patientLastName;

                        string[] patientFullName = appointment.PatientName.Split(" ");
                        patientFirstName = patientFullName[0];
                        patientLastName = patientFullName[^1];

                        // retrieve patient email using PatientDTO
                        Patient = await PatientService.GetPatientNameAndEmail(patientFirstName, patientLastName);

                        if (Patient != null)
                        {
                            if (Patient.Email == null)
                            {
                                // add patient name to the list of patients NOT sent emails
                                noEmailList.Add($"{Patient.FirstName} {Patient.LastName}");
                            }
                            else
                            {
                                // create email
                                EmailAddress from = new ("dylan@dylancroweclinic.ie", "Dylan Crowe");
                                EmailAddress recipient = new (Patient.Email, $"{Patient.FirstName} {Patient.LastName}");
                                String subject = $"Physical Therapy Appointment Reminder: {appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}";
                                String plainTextContent = $"Dear {Patient.FirstName}," +
                                             $"\n\nYour physical therapy appointment with {appointment.TherapistName} is confirmed for " +
                                             $"{appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}." +
                                             $"\n\nWe look forward to seeing you then." +
                                             $"\n\nKind regards," +
                                             $"\n\nDylan Crowe" +
                                             $"\n\nPhone Number: 087 7774512" +
                                             $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                                             $"\nWebsite: https://dylancroweclinic.ie/";
                                String htmlContent = $"<div>Dear {Patient.FirstName},</div>" +
                                    $"<p></p>" +
                                    $"<div>Your physical therapy appointment with {appointment.TherapistName} is confirmed for " +
                                    $"{appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}.</div>" +
                                    $"<p></p>" +
                                    $"<div>We look forward to seeing you then.</div>" +
                                    $"<p></p>" +
                                    $"<div>Kind regards,</div>" +
                                    $"<p></p>" +
                                    $"<div>Dylan Crowe</div>" +
                                    $"<p></p>" +
                                    $"<div>Phone Number: 087 7774512</div>" +
                                    $"<div>Location: 33 Pembroke Street Lower, Dublin 2</div>" +
                                    $"<div>Website: https://dylancroweclinic.ie/ </div>";
                                SendGridMessage emailReminder = MailHelper.CreateSingleEmail(
                                    from,
                                    recipient,
                                    subject,
                                    plainTextContent, htmlContent
                                    );

                                var response = await EmailService.SendEmail(emailReminder);


                                if (response)                   // response returns true if <= 400
                                {
                                    // add name to list of email recipients
                                    emailRecipients.Add($"{Patient.FirstName} {Patient.LastName}");
                                }
                            }
                        }
                    }


                }
                if (emailRecipients.Count >= 1)
                {
                    SuccessStatusClass = "alert-success";
                    successMessage.Append($"Emails sent to patient(s): {emailRecipients[0]}");

                    if (emailRecipients.Count > 1)
                    {
                        for (int i = 1; i < emailRecipients.Count; i++)
                        {
                            successMessage.Append($", {emailRecipients[i]}");
                        }
                    }
                }

                if (noEmailList.Count >= 1)
                {
                    noEmailStatusClass = "alert-danger";
                    noEmailMessage.Append($"No email address available for patient(s): {noEmailList[0]}");

                    if (noEmailList.Count > 1)
                    {
                        for (int i = 1; i < noEmailList.Count; i++)
                        {
                            noEmailMessage.Append($", {noEmailList[i]}");
                        }
                    }
                }
            }

            else
            {
                sendingStatusClass = "alert-danger";
                sendingMessage = "Email reminders cannot be sent for dates in the past or more than five days in the future";
            }
        }
    }
}
