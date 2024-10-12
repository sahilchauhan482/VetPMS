using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class SetNewPasswordValidator:AbstractValidator<SetNewPasswordModel>
    {
        public SetNewPasswordValidator()
        {
            RuleFor(v => v.UserName)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(v => v.NewPassword)
                .NotEmpty().WithMessage("Password is required.");

        }
    }
}
