using FluentValidation;

namespace VetPMS.Application.Commands.Owners.CreateOwner
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(50).WithMessage("name must not exceed 50 characters.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(v => v.PhoneNumber)
               .NotEmpty().WithMessage("Phone number is required.")
               .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits.");

            RuleFor(v => v.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address must not exceed 500 characters.");
        }
    }
}
