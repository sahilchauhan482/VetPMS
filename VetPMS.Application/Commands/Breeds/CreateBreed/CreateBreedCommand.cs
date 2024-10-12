namespace VetPMS.Application.Commands.Breeds.CreateBreed
{
    public class CreateBreedCommand : IRequest<CreateBreedCommandResponse>
    {
        public required string Name { get; set; }
        public required string Origin { get; set; }
        public required int ClinicId { get; set; }

    }
}
