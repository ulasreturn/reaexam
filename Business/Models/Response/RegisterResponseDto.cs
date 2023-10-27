
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Response;

public class RegisterResponseDto
{
    public int UserId { get; set; } = default!;
  public string TCKimlikNo { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string UserName { get; set; } = default!;
  public string UserSurname { get; set; } = default!;
  public byte[] PasswordSalt { get; set; } = default!;
  public string Telephone { get; set; } = default!;
  public string Country { get; set; } = default!;
  public string City { get; set; } = default!;
  public RegisterResponseDto User { get; set; }

}
