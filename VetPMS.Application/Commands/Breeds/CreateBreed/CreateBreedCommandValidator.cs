using FluentValidation;

namespace VetPMS.Application.Commands.Breeds.CreateBreed
{
    public class CreateBreedCommandValidator : AbstractValidator<CreateBreedCommand>
    {
        public CreateBreedCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(v => v.Origin)
                .NotEmpty().WithMessage("Origin is required.")
                .MaximumLength(100).WithMessage("Origin must not exceed 100 characters.");
        }
    }
}
