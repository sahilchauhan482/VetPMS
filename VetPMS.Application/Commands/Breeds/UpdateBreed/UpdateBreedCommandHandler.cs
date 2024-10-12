using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Command.Breeds.UpdateBreed
{
    public class UpdateBreedCommandHandler : IRequestHandler<UpdateBreedCommand, UpdateBreedResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateBreedCommandHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<UpdateBreedResponse> Handle(UpdateBreedCommand request, CancellationToken cancellationToken)
        {
            var breed = await _context.Breeds.FirstOrDefaultAsync(x=>x.Id==request.Id && x.ClinicId==request.ClinicId, cancellationToken)?? throw new KeyNotFoundException("Breed not found.");
            breed.Name = request.Name;
            breed.Origin = request.Origin;

            await _context.SaveChangesAsync(cancellationToken);
            BreedDto dto = (BreedDto)breed;
            return new UpdateBreedResponse(dto);
        }
    }
}
