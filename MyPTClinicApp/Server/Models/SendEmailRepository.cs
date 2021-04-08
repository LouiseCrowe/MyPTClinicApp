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

        public async Task<bool> SendEmail(EmailMessage emailMessage)
        {
            // so get Blazor to trigger this code to send email to SendGrid, this works from a Console app already

            // code from SiteWebAssembly
            SendGridMessage msg = new SendGridMessage();
            EmailAddress from = new EmailAddress("dylan@dylancroweclinic.ie", "Dylan Crowe");
            EmailAddress recipient = new EmailAddress("louise.crowe7@gmail.com", "Louise Crowe");

            msg.SetSubject("Welcome to Dylan Crowe Physical Therapy Clinic");
            msg.SetFrom(from);
            msg.AddTo(recipient);
            msg.PlainTextContent = emailMessage.Content;

            Response response = await sendGridClient.SendEmailAsync(msg);
            if (Convert.ToInt32(response.StatusCode) >= 400)
            {
                return false;
            }
            return true;




            //var apiKey = "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";
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


        }
    }
}
