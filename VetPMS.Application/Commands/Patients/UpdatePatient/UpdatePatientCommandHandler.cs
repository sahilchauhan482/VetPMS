using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Patients.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePatientCommandHandler(ApplicationDbContext context)=> (_context) = (context);
        public async Task<UpdatePatientCommandResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id== request.Id && x.ClinicId==request.ClinicId, cancellationToken) ?? throw new KeyNotFoundException("Patient not found.");
            patient.PatientUpdateDetails(request.Name, request.BreedId, request.DOB, request.Colour,request.OwnerId);
            await _context.SaveChangesAsync(cancellationToken);
            var patientWithRelations = await _context.Patients
                 .Include(p => p.Owner)
                 .Include(o => o.Breed) 
                 .FirstOrDefaultAsync(p => p.Id == patient.Id, cancellationToken)??throw new KeyNotFoundException();
            PatientDto dto = (PatientDto)patientWithRelations;
            return new UpdatePatientCommandResponse(dto);
        }
    }
}
