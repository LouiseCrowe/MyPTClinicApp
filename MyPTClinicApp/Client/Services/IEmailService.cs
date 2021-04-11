using MyPTClinicApp.Shared;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(SendGridMessage emailMessage);
    }
}
