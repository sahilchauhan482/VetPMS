using FluentValidation;

namespace VetPMS.Application.Commands.Account.ResetPassword
{
    public class ResetPasswordCommandValidator:AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(v => v.UserName)
               .NotEmpty().WithMessage("UserName is required.")
               .EmailAddress().WithMessage("Invalid UserName format.")
               .MaximumLength(100).WithMessage("UserName must not exceed 100 characters.");

            RuleFor(v => v.NewPassword)
                .NotEmpty().WithMessage("New Password is required.")
                .MaximumLength(100).WithMessage("New Password must not exceed 100 characters.");
            RuleFor(v => v.Token)
                .NotEmpty().WithMessage("Token is required.");
               
        }
    }
}
