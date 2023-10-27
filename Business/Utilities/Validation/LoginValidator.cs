using Business.Models.Request;
using FluentValidation;

namespace Business.Utilities.Validation;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithName("Kullanıcı Adı");
        RuleFor(x => x.PasswordSalt).NotEmpty().WithName("Şifre");
    }
}
