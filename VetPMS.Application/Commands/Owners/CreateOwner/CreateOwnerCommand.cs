namespace VetPMS.Application.Commands.Owners.CreateOwner
{
    public class CreateOwnerCommand:IRequest<CreateOwnerResponse>
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public  int? ClinicId { get; set; }

    }
}
