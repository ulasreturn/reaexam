namespace Business.Models.Request;

public class LoginDto
{
    public string Email { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;
}
