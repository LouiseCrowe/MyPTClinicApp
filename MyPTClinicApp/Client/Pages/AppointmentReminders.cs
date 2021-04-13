using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class AppointmentReminders
    {
        [Inject]
        public IAppointmentService AppointmentService { get; set; }

        // GOING TO TRY TO USE APPOINTMENTS FOR REMINDERS
        //[Inject]
        //public ITreatmentService TreatmentService { get; set; }

        [Inject]
        public IPatientService PatientService { get; set; }

        [Inject]
        public ITherapistService TherapistService { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        //// using treatment table to get information for appointments because treatments have Patient ID (needed to send email)
        //// appointments is a class to interact with Telerik scheduler does not contain Patient ID
        //private IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment>();

        // set default date to the next day
        public DateTime AppointmentsDate { get; set; } = DateTime.Now.AddDays(2);

        public List<SchedulerAppointment> Appointments { get; set; } = new();

        public PatientDTO Patient { get; set; } = new();

        protected List<string> emailRecipients = new ();
        protected List<string> noEmailList = new();

        // for managing screen messages regarding sending emails
        protected string SuccessStatusClass = string.Empty;
        protected string successMessage = string.Empty;
        protected string noEmailStatusClass = string.Empty;
        protected string noEmailMessage = string.Empty;
        protected string sendingStatusClass = string.Empty;
        protected string sendingMessage = string.Empty;

        //TRYING TO USE APPOINTMENT FOR REMINDER EMAILS
        //// for finding Patient and Therapist for sending reminder emails
        //Patient patient = new();
        //Therapist therapist = new();

        protected override async Task OnInitializedAsync()
        {
            //// get a list of Appointments based on the Treatments records
            //// defaults to next day 
            //Treatments = await TreatmentService.GetTreatmentsByDate(AppointmentsDate.Year, AppointmentsDate.Month, AppointmentsDate.Day);            

            Appointments = await AppointmentService.GetAppointmentsByDate(AppointmentsDate.Year, AppointmentsDate.Month, AppointmentsDate.Day);
            
        }

        public async Task GetAppointments()
        {
            Appointments = await AppointmentService.GetAppointmentsByDate(AppointmentsDate.Year, AppointmentsDate.Month, AppointmentsDate.Day);
            // clear errors from screen 
            SuccessStatusClass = string.Empty;
            successMessage = string.Empty;
            noEmailStatusClass = string.Empty;
            noEmailMessage = string.Empty;
            sendingStatusClass = string.Empty;
            sendingMessage = string.Empty;
    }

        
        protected async Task SendReminderMails()
        {
            if (AppointmentsDate >= DateTime.Now && AppointmentsDate <= DateTime.Now.AddDays(5) && Appointments.Count >= 1)
            {
                SendGridMessage msg = new();
                EmailAddress from = new("dylan@dylancroweclinic.ie", "Dylan Crowe");

                foreach (SchedulerAppointment appointment in Appointments)
                {
                    if (appointment.PatientName != "" || appointment.PatientName != "To Be Confirmed")
                    {
                        // find patient to include in treatment based on name in appointment
                        string patientFirstName, patientLastName;

                        string[] patientFullName = appointment.PatientName.Split(" ");
                        patientFirstName = patientFullName[0];
                        patientLastName = patientFullName[^1];

                        // find patient using Patient name - THIS IS THE PROBLEM maybe jst need PatientDTO
                        Patient = await PatientService.GetPatientNameAndEmail(patientFirstName, patientLastName);

                        if (Patient != null)
                        {
                            if (Patient.Email == null)
                            {
                                noEmailList.Add($"{Patient.FirstName} {Patient.LastName}");
                            }
                            else
                            {
                                // create email
                                EmailAddress recipient = new(Patient.Email, $"{Patient.FirstName} {Patient.LastName}");
                                msg.SetSubject($"Physical Therapy Appointment Reminder: {appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}");
                                msg.SetFrom(from);
                                msg.AddTo(recipient);
                                msg.PlainTextContent = $"Dear {Patient.FirstName}" +
                                             $"\n\nYour physical therapy appointment with {appointment.TherapistName} is confirmed for " +
                                             $"{appointment.Start.ToShortDateString()} at {appointment.Start.ToShortTimeString()}." +
                                             $"\n\nWe look forward to seeing you then." +
                                             $"\n\nKind regards," +
                                             $"\n\nDylan Crowe" +
                                             $"\n\nPhone Number: 087 7774512" +
                                             $"\nLocation: 33 Pembroke Street Lower, Dublin 2" +
                                             $"\nWebsite: https://dylancroweclinic.ie/";

                                var response = await EmailService.SendEmail(msg);

                                if (response)                   // response returns true if <= 400
                                {
                                    // add name to list of email recipients
                                    emailRecipients.Add($"{Patient.FirstName} {Patient.LastName}");
                                }

                            }

                        }


                    }

                    if (emailRecipients.Count >= 1)
                    {
                        SuccessStatusClass = "alert-success";
                        successMessage = $"Emails sent to patient(s): {emailRecipients[0]}";

                        if (emailRecipients.Count > 1)
                        {
                            for (int i = 1; i < emailRecipients.Count; i++)
                            {
                                successMessage += $", {emailRecipients[i]}";
                            }

                        }
                    }

                    if (noEmailList.Count >= 1)
                    {
                        noEmailStatusClass = "alert-danger";
                        noEmailMessage = $"No email address available for patient(s): {noEmailList[0]}";

                        if (noEmailList.Count > 1)
                        {
                            for (int i = 1; i < noEmailList.Count; i++)
                            {
                                noEmailMessage += $", {noEmailList[i]}";
                            }
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
