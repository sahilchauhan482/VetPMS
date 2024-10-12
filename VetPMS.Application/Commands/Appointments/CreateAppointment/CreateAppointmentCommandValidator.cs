using FluentValidation;

namespace VetPMS.Application.Commands.Appointments.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("OwnerId must be a positive integer.");

            RuleFor(x => x.BreedId)
                .GreaterThan(0).WithMessage("BreedId must be a positive integer.");

            RuleFor(x => x.Services)
                .NotEmpty().WithMessage("Services must not be empty.")
                .MaximumLength(200).WithMessage("Services cannot exceed 200 characters.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title must not be empty.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Start)
                .Must(start => start == null || start > DateTime.Now).WithMessage("Start date must be in the future.");

            RuleFor(x => x.End)
                .Must((command, end) => end == null || (command.Start != null && end > command.Start))
                .WithMessage("End date must be after the Start date if provided.");

            RuleFor(x => x.Comments)
                .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters.");
        }
    }
}
