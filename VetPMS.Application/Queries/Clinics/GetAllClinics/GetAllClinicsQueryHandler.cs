using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Clinics.GetAllClinics
{
    public class GetAllClinicsQueryHandler : IRequestHandler<GetAllClinicsQuery,GetAllClinicsQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllClinicsQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<GetAllClinicsQueryResponse>Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
        {
            var clinics = await _context.Clinics.ToListAsync(cancellationToken);

            var ClinicDto= clinics.Select(clinic => (ClinicDto)clinic).ToList(); 

            return new GetAllClinicsQueryResponse(ClinicDto);
        }
    }
}
