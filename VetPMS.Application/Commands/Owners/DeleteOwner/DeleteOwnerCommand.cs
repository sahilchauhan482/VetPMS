namespace VetPMS.Application.Commands.Owners.DeleteOwner
{
    public class DeleteOwnerCommand:IRequest<DeleteOwnerCommandResponse>
    {
        public int Id { get; set; }
        public int? ClinicId { get; set; }
    }
}
