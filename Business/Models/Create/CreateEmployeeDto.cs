using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Create
{
    public class CreateEmployeeDto
    {
        public int UserId { get; set; } = default!;
        public string Cinsiyet { get; set; } = default!;
        public DateTime DogumTarihi { get; set; } = default!;
        public string UzmanlikAlani { get; set; } = default!;





    }
}
