using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailMessage emailMessage);
    }
}
