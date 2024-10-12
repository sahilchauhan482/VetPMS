namespace VetPMS.Application.Commands.Registers
{
    public class CreateUserRegisterCommand:IRequest<CreateUserRegisterResponse>
    {
        public required string FullName { get; set; }
        public required string Gender { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public int? ClinicId { get; set; }

    }
}
