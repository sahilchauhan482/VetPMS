using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Owners.GetAllOwners
{
    public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery,GetAllOwnersQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public GetAllOwnersQueryHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<GetAllOwnersQueryResponse> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _context.Owners.Where(o=>o.ClinicId==request.ClinicId).ToListAsync(cancellationToken);
            var dto = owners.Select(owner => (OwnerDto)owner).ToList();

            return new GetAllOwnersQueryResponse(dto);
        }

    }
}
