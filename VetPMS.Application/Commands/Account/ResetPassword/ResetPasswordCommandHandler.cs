using Microsoft.AspNetCore.Identity;
using System.Net;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Account.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordCommandResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ResetPasswordCommandHandler(UserManager<IdentityUser> userManager)
            => (_userManager) = (userManager);

        public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.UserName) ?? throw new KeyNotFoundException("User not found.");
            //var decodedToken = WebUtility.UrlDecode(request.Token);
            var resetPassResult = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!resetPassResult.Succeeded)
            {
                var errors = string.Join(", ", resetPassResult.Errors.Select(e => e.Description));
                throw new Exception($"Password reset failed: {errors}");
            }
            return GenerateResetPasswordResponse(request);
        }


        private static ResetPasswordCommandResponse GenerateResetPasswordResponse(ResetPasswordCommand request)
        {
            return new ResetPasswordCommandResponse
            (
                new ResetPasswordDto
                {
                    UserName = request.UserName,
                    NewPassword = request.NewPassword,
                    Token = request.Token
                }
            );
        }
    }
}
