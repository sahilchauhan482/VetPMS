namespace VetPMS.Application.Command.Breeds.DeleteBreed
{
    public class DeleteBreedCommandHandler : IRequestHandler<DeleteBreedCommand, DeleteBreedCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBreedCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<DeleteBreedCommandResponse> Handle(DeleteBreedCommand request, CancellationToken cancellationToken)
        {
            var breed = await _context.Breeds.FirstOrDefaultAsync(x=>x.Id==request.Id && x.ClinicId ==request.ClinicId,cancellationToken)?? throw new KeyNotFoundException("Breed not found.");
            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteBreedCommandResponse(true);
        }
    }
}
