using VetPMS.Application.Query.Patients.GetPatient;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Patients.GetPatient
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GetPatientQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetPatientQueryHandler(ApplicationDbContext context) => (_context) = (context);
       
        public async Task<GetPatientQueryResponse> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients
                .Include(p => p.Owner).Include(b=>b.Breed)
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.ClinicId==request.ClinicId, cancellationToken)?? throw new InvalidOperationException("Patient not found.");
            PatientDto dto = (PatientDto)patient;
            return new GetPatientQueryResponse(dto);
        }
    }
}
