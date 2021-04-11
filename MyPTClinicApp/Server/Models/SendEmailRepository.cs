using MyPTClinicApp.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public class SendEmailRepository : ISendEmailRepository
    {
        private readonly ISendGridClient sendGridClient;
        private readonly HttpClient httpClient;

        public SendEmailRepository(ISendGridClient sendGridClient, HttpClient httpClient)
        {
            this.sendGridClient = sendGridClient;
            this.httpClient = httpClient;
        }

        public async Task<bool> SendEmail(SendGridMessage emailMessage)
        {
            Response response = await sendGridClient.SendEmailAsync(emailMessage);
            if (Convert.ToInt32(response.StatusCode) >= 400)
            {
                return false;
            }
            return true;

<<<<<<< HEAD
=======



            //var apiKey = "INSERT API KEY HERE";
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("dylan@dylancroweclinic.ie", "Dylan");
            //var to = new EmailAddress("x00159407@mytudublin.ie", "TUD");
            //var to = new EmailAddress("louise_emily_murphy@hotmail.com", "Louise Hotmail");
            //var to = new EmailAddress("louise.crowe7@gmail.com", "Louise Gmail");
            //var subject = "Sending from Console App using SendGrid";
            //var plainTextContent = "I'm very happy if this works";
            //var htmlContent = "<strong>Sending from Console App</strong>";
            //var msg = MailHelper.CreateSingleEmail(
            //    from,
            //    to,
            //    subject,
            //    plainTextContent, htmlContent
            //    );

            //Response response = await sendGridClient.SendEmailAsync(msg);
            //if (Convert.ToInt32(response.StatusCode) >= 400)
            //{
            //    return false;
            //}
            //return true;


>>>>>>> b4281003485b411f63ef2cc2727846f973d28726
        }
    }
}
