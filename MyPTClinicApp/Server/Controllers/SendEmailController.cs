using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPTClinicApp.Server.Models;
using SendGrid.Helpers.Mail;
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
        public async Task<ActionResult> SendEmail([FromBody] SendGridMessage emailMessage)
        {
            try
            {
                if (emailMessage == null)
                {
                    return BadRequest();
                }

                bool response = await sendEmailRepository.SendEmail(emailMessage);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
