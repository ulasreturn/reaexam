using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Web.Controllers.Base;
using Infrastructure.Data.Postgres.EntityFramework;

namespace Web.Controllers
{
    public class BankAccountController : BaseCrudController<BankAccount, int, CreateBankAccountDto, UpdateBankAccountDto, BankAccountInfoDto>
    {
        private PostgresContext _context;
        public BankAccountController(IBankAccountService service, PostgresContext context) : base(service)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllRandevu()
        {
            // Comment verilerini yükleyin
            var hesaplar = _context.BankAccount
                  .Include(c => c.Customer)
                          .Select(acc => new
                          {
                              
                              MusteriTC=acc.Customer.TCKimlikNo,
                              MusteriAdi= acc.Customer.UserName,
                              MusteriSoyadi = acc.Customer.UserSurname,
                              
                       
                              
                        
                              
                             
                          })
              .ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 500 // Derinlik sýnýrýný artýrýn
            };
            var json = JsonSerializer.Serialize(hesaplar, options);

            // JSON formatýnda yanýt döndürmek için bir IActionResult oluþturun
            IActionResult response = new ContentResult
            {

                Content = json,  // Verileri JSON formatýna dönüþtürün
                ContentType = "application/json", // Ýçerik türünü JSON olarak belirtin
                StatusCode = 200 // HTTP 200 (Baþarýlý) durum kodunu ayarlayýn
            };

            return response;


        }
    }
}
