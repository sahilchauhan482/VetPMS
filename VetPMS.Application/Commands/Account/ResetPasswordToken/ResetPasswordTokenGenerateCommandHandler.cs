using Microsoft.AspNetCore.Identity;
using System.Net;
using VetPMS.Domain.DTOs;
using VetPMS.Infrastructure.Email;

namespace VetPMS.Application.Commands.Account.ResetPasswordToken
{
    public class ResetPasswordTokenGenerateCommandHandler : IRequestHandler<ResetPasswordTokenGenerateCommand, ResetPasswordTokenGenerateResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EmailService _emailService;

        public ResetPasswordTokenGenerateCommandHandler(UserManager<IdentityUser> userManager, EmailService emailService) =>
            (_userManager, _emailService) = (userManager, emailService);

        public async Task<ResetPasswordTokenGenerateResponse> Handle(ResetPasswordTokenGenerateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName) ?? throw new KeyNotFoundException("User not found.");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = GenerateResetLink(token, request.UserName);
            var emailBody = CreateEmailBody(resetLink);
            if (string.IsNullOrEmpty(user.UserName)) throw new InvalidOperationException("UserName is null or empty.");
            if (string.IsNullOrEmpty(user.Email)) throw new InvalidOperationException("UserEmail is null or empty.");
            await _emailService.SendEmailAsync(user.Email, "Password Reset", emailBody);
            return new ResetPasswordTokenGenerateResponse("Reset password token sent to your email.");
        }

       
        private static string GenerateResetLink(string token, string userName)
        {
            return $"https://localhost:7248/set-new-password?token={WebUtility.UrlEncode(token)}&username={WebUtility.UrlEncode(userName)}";
        }

        private static string CreateEmailBody(string resetLink)
        {
            return $"Click the link to reset your password: {resetLink}";
        }

       
    }
}
