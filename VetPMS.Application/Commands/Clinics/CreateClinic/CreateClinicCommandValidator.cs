using FluentValidation;

namespace VetPMS.Application.Commands.Clinics.CreateClinic
{
    public class CreateClinicCommandValidator : AbstractValidator<CreateClinicCommand>
    {
        public CreateClinicCommandValidator()
        {
            RuleFor(v => v.ClinicName)
                .NotEmpty().WithMessage("Clinic name is required.")
                .MaximumLength(100).WithMessage("Clinic name must not exceed 100 characters.");

            RuleFor(v => v.ClinicEmail)
                .NotEmpty().WithMessage("Clinic email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Clinic email must not exceed 100 characters.");

            RuleFor(v => v.ClinicPhone)
    .NotEmpty().WithMessage("Clinic phone is required.")
    .Matches(@"^\d{10}$").WithMessage("Clinic phone must start with +91 and be followed by exactly 10 digits.");

            RuleFor(v => v.ClinicAddress)
                .NotEmpty().WithMessage("Clinic address is required.")
                .MaximumLength(500).WithMessage("Clinic address must not exceed 500 characters.");
        }
    }
}
