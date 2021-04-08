using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPTClinicApp.Server.Models;
using MyPTClinicApp.Shared;
using System;
using System.Threading.Tasks;


namespace MyPTClinicApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
          private readonly ISendEmailRepository sendEmailRepository;

        public SendEmailController(ISendEmailRepository sendEmailRepository)
        {
            this.sendEmailRepository = sendEmailRepository;
        }


        //POST: api/sendemail
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SendEmail([FromBody] EmailMessage emailmessage)
        {
            try
            {
                if (string.IsNullOrEmpty(emailmessage.SenderAddress) || string.IsNullOrEmpty(emailmessage.Content) || string.IsNullOrEmpty(emailmessage.RecipientAddress))
                {
                    return BadRequest();
                }

                bool response = await sendEmailRepository.SendEmail(emailmessage);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        

    }
}
