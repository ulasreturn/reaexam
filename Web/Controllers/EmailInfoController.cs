using Microsoft.AspNetCore.Mvc;
using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;
using Business.Services;

namespace Web.Controllers
{
 
  public class EmailInfoController : BaseCrudController<User,int, CreateUserDto, UserUpdateDto, EmailInfoDTO>
  {
    IEmailInfoService _emailInfoService;
    public EmailInfoController(IEmailInfoService service) : base(service)
    {
      _emailInfoService = service;
    }

  }
}
