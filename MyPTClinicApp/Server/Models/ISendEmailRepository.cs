using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface ISendEmailRepository
    {
        Task<bool> SendEmail(SendGridMessage emailMessage);
    }
}
