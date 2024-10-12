using FluentValidation;

namespace VetPMS.Application.Commands.Account.ResetPasswordToken
{
    public class ResetPasswordTokenGenerateCommandValidator:AbstractValidator<ResetPasswordTokenGenerateCommand>
    {
        public ResetPasswordTokenGenerateCommandValidator()
        {
            RuleFor(v => v.UserName)
              .NotEmpty().WithMessage("UserName is required.")
              .EmailAddress().WithMessage("Invalid UserName format.")
              .MaximumLength(100).WithMessage("UserName must not exceed 100 characters.");
            
        }
    }
}
