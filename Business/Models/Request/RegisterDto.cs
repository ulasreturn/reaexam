using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Request;

public class RegisterDto
{
  public string TCKimlikNo { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string UserName { get; set; } = default!;
  public string UserSurname { get; set; } = default!;
  public string Password { get; set; } = default!;
  public string Telephone { get; set; } = default!;
  public string Country { get; set; } = default!;
  public string City { get; set; } = default!;
  public string UserPhoto { get; set; } = default!;

    public UserType UserType { get; set; } = default!;

}
