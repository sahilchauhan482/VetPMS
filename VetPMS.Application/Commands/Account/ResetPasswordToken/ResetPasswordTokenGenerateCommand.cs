namespace VetPMS.Application.Commands.Account.ResetPasswordToken
{
    public class ResetPasswordTokenGenerateCommand:IRequest<ResetPasswordTokenGenerateResponse>
    {
        public required string UserName { get; set; }
    }
}
