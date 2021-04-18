using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(SendGridMessage emailMessage);
    }
}
