using FluentValidation;
using VetPMS.Models;

namespace VetPMS.Validator
{
    public class BreedValidator : AbstractValidator<BreedDTO>
    {
        public BreedValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.Origin)
                .NotEmpty().WithMessage("Origin is required.");

        }
    }
   
}
