using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class LoginValidator : AbstractValidator<AuthLogin>
    {
        public LoginValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.");
                
        }
    }
}
