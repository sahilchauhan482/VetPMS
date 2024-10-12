using FluentValidation;

namespace VetPMS.Application.Commands.Appointments.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Appointment ID must be greater than 0.");

            
            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Owner ID must be greater than 0.");

           
            RuleFor(x => x.BreedId)
                .GreaterThan(0).WithMessage("Breed ID must be greater than 0.");

            
            RuleFor(x => x.Start)
                .NotNull().WithMessage("Start time is required.");

            RuleFor(x => x.End)
                .GreaterThan(x => x.Start).When(x => x.End.HasValue)
                .WithMessage("End time must be after the start time.");

            
            RuleFor(x => x.Services)
                .NotEmpty().WithMessage("Services are required.");

            
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.");

            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

           
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.");

            
        }
    }
}
