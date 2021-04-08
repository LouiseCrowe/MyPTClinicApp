using MyPTClinicApp.Shared;
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


        public async Task<bool> SendEmail(EmailMessage emailMessage)
        {
            var newEmail = new StringContent(System.Text.Json.JsonSerializer.Serialize(emailMessage), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:5001/api/sendemail", newEmail);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;


            //// from SiteWASM
            //using HttpContent requestBody = new StringContent(JsonConvert.SerializeObject(emailMessage));
            //requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Uri requestUri = new Uri($"/api/sendemail/contact", UriKind.Relative);
            //var response = await httpClient.PostAsync(requestUri, requestBody).ConfigureAwait(false);

            //if (response.IsSuccessStatusCode)
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
