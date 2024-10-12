using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Breed.GetBreed
{
    public class GetBreedQueryHandler : IRequestHandler<GetBreedQuery, GetBreedQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetBreedQueryHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<GetBreedQueryResponse> Handle(GetBreedQuery request, CancellationToken cancellationToken)
        {
            var breed = await _context.Breeds.FirstOrDefaultAsync(x=>x.Id== request.Id && x.ClinicId==request.ClinicId, cancellationToken)?? throw new KeyNotFoundException("Not found with this Id");
            BreedDto dto = (BreedDto)breed;
            return new GetBreedQueryResponse(dto);
        }
    }
}
