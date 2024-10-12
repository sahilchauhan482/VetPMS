using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class ClinicValidator : AbstractValidator<ClinicDto>
    {
        public ClinicValidator()
        {
            RuleFor(v => v.ClinicName)
                .NotEmpty().WithMessage("Clinic name is required.")
                .MaximumLength(100).WithMessage("Clinic name must not exceed 100 characters.");

            RuleFor(v => v.ClinicAddress)
                .NotEmpty().WithMessage("Clinic address is required.")
                .MaximumLength(500).WithMessage("Clinic address must not exceed 500 characters.");

            RuleFor(v => v.ClinicPhone)
               .NotEmpty().WithMessage("Clinic phone number is required.")
               .Matches(@"^\d{10}$").WithMessage("Clinic phone number must be exactly 10 digits.");

            RuleFor(v => v.ClinicEmail)
                .NotEmpty().WithMessage("Clinic email is required.")
                .EmailAddress().WithMessage("Invalid clinic email format.")
                .MaximumLength(100).WithMessage("Clinic email must not exceed 100 characters.");

            RuleFor(v => v.EstablishedDate)
                .NotEmpty().WithMessage("Established date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Established date must be in the past.");
        }
    }
}
