using FluentValidation;

namespace VetPMS.Application.Commands.Account.Authentication
{
    public class CreateLoginCommandValidator:AbstractValidator<CreateLoginCommand>
    {
        public CreateLoginCommandValidator()
        {
            RuleFor(v => v.Email)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email format.")
               .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        }
    }
}
