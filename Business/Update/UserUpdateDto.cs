
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class UserUpdateDto
    {
    //  public int UserID { get; set; } = default!;
 
    public string TCKimlikNo { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string UserSurname { get; set; } = default!;
    public byte[] PasswordSalt { get; set; }
    public string Telephone { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string City { get; set; } = default!;

    public UserType UserType { get; set; }
   

  


  }
}
