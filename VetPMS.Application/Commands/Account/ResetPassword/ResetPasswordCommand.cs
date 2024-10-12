namespace VetPMS.Application.Commands.Account.ResetPassword
{
    public class ResetPasswordCommand:IRequest<ResetPasswordCommandResponse>
    {
        public required string UserName { get; set; }
        public required string NewPassword { get; set; }
        public required string Token { get; set; }
    }
}
