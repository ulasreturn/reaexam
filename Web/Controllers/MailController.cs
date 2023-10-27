using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;
using Core.Utilities.Mail;
using Microsoft.AspNetCore.Mvc;
using Business.Utilities.Mapping.Interface;
using Web.Model;

namespace Web.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
      private readonly IMailHelper _mailHelper;

      public MailController(IMailHelper mailHelper)
      {
        _mailHelper = mailHelper;
      }

      [HttpPost]
      public async Task<IActionResult> SendEmail([FromBody] EmailModel model)
      {
        try
        {
          // E-posta gönderme işlemini burada gerçekleştirin
          await _mailHelper.SendMailAsync(model.Subject, model.Body, model.Recepients);
          return Ok();
        }
        catch (Exception ex)
        {
          return BadRequest();
        }
      }
    }
  
}
