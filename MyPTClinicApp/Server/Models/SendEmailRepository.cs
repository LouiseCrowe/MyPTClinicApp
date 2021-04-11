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



        }
    }
}
