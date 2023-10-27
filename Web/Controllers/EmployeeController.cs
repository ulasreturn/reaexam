using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers.Base;

namespace Web.Controllers
{
   

    public class EmployeeController : BaseCrudController<Employee, int, CreateEmployeeDto, UpdateEmployeeDto, EmployeeInfoDto>
    {
        private readonly IEmployeeService doktorService;
        public EmployeeController(IEmployeeService service, PostgresContext dbContext) : base(service)
        {
            doktorService = service;
        }
        [HttpPost("updateUserTypeToDoktor/{userId}")]
        public IActionResult UpdateUserTypeToDoktor(int userId)
        {
            bool success = doktorService.UpdateUserTypeToEmployee(userId);

            if (success)
            {
                return Ok("Kullanýcý tipi baþarýyla güncellendi.");
            }
            else
            {
                return NotFound("Kullanýcý bulunamadý.");
            }
        }

        private IActionResult NotFound(string v)
        {
            throw new NotImplementedException();
        }

        private IActionResult Ok(string v)
        {
            throw new NotImplementedException();
        }
    }
}
