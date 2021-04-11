using MyPTClinicApp.Shared;
using SendGrid.Helpers.Mail;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient httpClient;

        public EmailService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<bool> SendEmail(SendGridMessage emailMessage)
        {
            var newEmail = new StringContent(System.Text.Json.JsonSerializer.Serialize(emailMessage), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:5001/api/sendemail", newEmail);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
