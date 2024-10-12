using VetPMS.Application.Query.Patients.GetAllPatients;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Patients.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, GetAllPatientsQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllPatientsQueryHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<GetAllPatientsQueryResponse> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _context.Patients.Where(x=>x.ClinicId==request.ClinicId)
                .Include(p => p.Owner).Include(b=>b.Breed)
                .ToListAsync(cancellationToken);
            var dto = patients.Select(patient => (PatientDto)patient).ToList();
            return new GetAllPatientsQueryResponse(dto);
        }
    }
}
