namespace VetPMS.Application.Commands.Account.Authentication
{
    public class CreateLoginCommand:IRequest<CreateLoginCommandResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
