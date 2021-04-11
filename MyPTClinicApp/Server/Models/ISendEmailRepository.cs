using MyPTClinicApp.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.Models.IdentityResources;

namespace MyPTClinicApp.Server.Models
{
    public interface ISendEmailRepository
    {
        Task<bool> SendEmail(SendGridMessage email);
    }
}
