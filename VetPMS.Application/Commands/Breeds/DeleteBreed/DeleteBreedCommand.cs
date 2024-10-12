namespace VetPMS.Application.Command.Breeds.DeleteBreed
{
    public class DeleteBreedCommand : IRequest<DeleteBreedCommandResponse>
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
