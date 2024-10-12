using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class ResetPasswordValidator:AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordValidator()
        {
            RuleFor(v => v.UserName)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
