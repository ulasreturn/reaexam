using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class TransactionsController : BaseCrudController<Transactions, int, CreateTransactionsDto, UpdateTransactionsDto, TransactionsInfoDto>
    {
        public TransactionsController(ITransactionsService service) : base(service)
        {
        }

    }
}
