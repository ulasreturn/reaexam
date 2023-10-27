using Business.Models.Response;
using Business.Models.Request.Functional;
using Business.Services.Base.Interface;
using Core.Results;
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
  
    public interface IEmailInfoService : IBaseService<User, int, EmailInfoDTO>
    {
    }
  
}
