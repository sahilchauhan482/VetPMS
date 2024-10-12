using VetPMS.Application.Queries.Clinics.GetClinic;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Clinics.GetClinicById
{
    public class GetClinicByIdQueryHandler : IRequestHandler<GetClinicByIdQuery, GetClinicByIdQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetClinicByIdQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<GetClinicByIdQueryResponse> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = await _context.Clinics.FindAsync(request.Id);

            if (clinic == null)
                throw new KeyNotFoundException($"Clinic with ID {request.Id} not found.");

            var ClinicDto= (ClinicDto)clinic;
            return new GetClinicByIdQueryResponse(ClinicDto);
        }
    }
}
