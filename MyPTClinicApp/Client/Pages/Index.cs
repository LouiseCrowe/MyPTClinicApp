using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class Index
    {
        // for sending welcome mail
        [Inject]
        public IEmailService EmailService { get; set; }

        private EmailMessage EmailMessage { get; set; }
        private string uiMessage = "Haven't tried sending yet";


        protected async void SendWelcomeMail()
        {
            EmailMessage emailMessage = new EmailMessage()

            {
                RecipientAddress = "louise.crowe7@gmail.com",
                RecipientName = "Louise Crowe",
                SenderAddress = "dylan@dylancroweclinic.ie",
                SenderName = "Dylan Crowe",
                Subject = "Welcome to Dylan Crowe Physical Therapy Clinic",
                Content = "We are delighted to have you on board.  Contact details: 087 7774512"               
            };

            bool response = await EmailService.SendEmail(emailMessage);
            if (response)
            {
                uiMessage = "Message sent!";
            }
            else
            {
                uiMessage = "There was an error sending the message";
            }

        }

    }
}
