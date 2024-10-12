namespace VetPMS.Application.Command.Breeds.UpdateBreed
{
    public class UpdateBreedCommand : IRequest<UpdateBreedResponse>
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public required string Name { get; set; }
        public required string Origin { get; set; }
    }
}
