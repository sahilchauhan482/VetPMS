using FluentValidation;

namespace VetPMS.Application.Commands.Patients.CreatePatient
{
    public class CreatePatientCommandValidator: AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(v => v.OwnerId)
                .NotEmpty().WithMessage("OwnerId is required.");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("name is required.")
                .MaximumLength(50).WithMessage("name must not exceed 50 characters.");
            RuleFor(v => v.BreedId)
                .NotEmpty().WithMessage("Breed is required.");
               
            RuleFor(v => v.Colour)
                .NotEmpty().WithMessage("Colour is required.")
                .MaximumLength(50).WithMessage("Colour must not exceed 50 characters.");
            RuleFor(v => v.DOB)
                .NotEmpty().WithMessage("DOB is required.");
                
        }
    }
}
