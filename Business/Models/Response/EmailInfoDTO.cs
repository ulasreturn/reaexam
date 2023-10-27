using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Response
{
  public class EmailInfoDTO
  {
    public string Email { get; set; } = default!;
  }
}
