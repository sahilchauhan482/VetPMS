using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Breed.GetAllBreeds
{
    public class GetAllBreedsQueryHandler : IRequestHandler<GetAllBreedsQuery,GetAllBreedsQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllBreedsQueryHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<GetAllBreedsQueryResponse> Handle(GetAllBreedsQuery request, CancellationToken cancellationToken)
        {
            var dto = await _context.Breeds.Where(x=>x.ClinicId==request.ClinicId).Select(b => (BreedDto)b).ToListAsync(cancellationToken);
            return new GetAllBreedsQueryResponse(dto);
        }
    }
}
