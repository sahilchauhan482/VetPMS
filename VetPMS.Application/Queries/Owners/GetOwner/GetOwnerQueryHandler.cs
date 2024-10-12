using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Owners.GetOwner
{
    public class GetOwnerQueryHandler : IRequestHandler<GetOwnerQuery, GetOwnerQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public GetOwnerQueryHandler(ApplicationDbContext context) => (_context) = (context);
       
        public async Task<GetOwnerQueryResponse> Handle(GetOwnerQuery request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners
                .FirstOrDefaultAsync(o => o.Id == request.Id && o.ClinicId == request.ClinicId, cancellationToken)?? throw new KeyNotFoundException($"Owner with ID {request.Id} not found.");
            OwnerDto dto = (OwnerDto)owner;
            return new GetOwnerQueryResponse(dto);
        }
    }

}

