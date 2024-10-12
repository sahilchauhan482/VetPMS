using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class AppointmentValidator : AbstractValidator<AppointmentDTO>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Owner is required.");

            RuleFor(x => x.BreedId)
                .GreaterThan(0).WithMessage("Breed is required.");

            RuleFor(x => x.Services)
                .NotEmpty().WithMessage("Services is required.")
                .MaximumLength(200).WithMessage("Services cannot exceed 200 characters.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Phone)
    .NotEmpty()
    .WithMessage("Phone number is required.")
    .Matches(@"^\+91\d{10}$")
    .WithMessage("Phone number must start with +91 and be followed by 10 digits.");

            RuleFor(x => x.Start)
            .NotEmpty()
            .WithMessage("Start date is required.")
            .LessThanOrEqualTo(x => x.End)
            .WithMessage("Start date must be equal or before the end date.");

            RuleFor(x => x.End)
                .NotEmpty()
                .WithMessage("End date is required.")
                .GreaterThanOrEqualTo(x => x.Start)
                .WithMessage("End date must be equal or after the start date.");

            RuleFor(x => x.Comments)
                .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters.");

        }
    }
}
