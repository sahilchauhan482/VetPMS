namespace VetPMS.Application.Commands.Owners.UpdateOwner
{
    public class UpdateOwnerCommand:IRequest<UpdateOwnerCommandResponse>
    {
        public int Id { get; set; }
        public int? ClinicId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
