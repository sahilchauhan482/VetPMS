using FluentValidation;

namespace VetPMS.Application.Commands.Registers
{
    public class CreateUserRegisterValidator: AbstractValidator<CreateUserRegisterCommand>
    {
        public CreateUserRegisterValidator()
        {
            RuleFor(v => v.FullName)
                 .NotEmpty().WithMessage("name is required.")
                 .MaximumLength(50).WithMessage("name must not exceed 50 characters.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(v => v.PhoneNumber)
               .NotEmpty().WithMessage("Phone number is required.")
               .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits.");
        }
    }
}
