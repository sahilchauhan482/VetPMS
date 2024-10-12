using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class PatientValidator : AbstractValidator<PatientsDTO>
    {
        public PatientValidator()
        {
            RuleFor(v => v.OwnerId)
               .NotEmpty().WithMessage("Owner is required.");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
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
