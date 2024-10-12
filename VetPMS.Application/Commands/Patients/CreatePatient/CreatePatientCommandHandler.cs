using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Patients.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreatePatientCommandHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<CreatePatientCommandResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            if (string.IsNullOrEmpty(request.Name) ||
                string.IsNullOrEmpty(request.Colour) ||
                request.DOB == default ||
                request.OwnerId <= 0)
            {
                throw new ArgumentException("One or more fields are invalid.");
            }
            var patient = new Patient(request.Name, request.BreedId, request.DOB, request.Colour, request.OwnerId,request.ClinicId);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync(cancellationToken);
            var patientWithRelations = await _context.Patients
                .Include(p => p.Owner)
                .Include(o => o.Breed)
                .FirstOrDefaultAsync(p => p.Id == patient.Id, cancellationToken) ?? throw new KeyNotFoundException();
            PatientDto dto = (PatientDto)patientWithRelations;
            return new CreatePatientCommandResponse(dto);
        }
    }
}
