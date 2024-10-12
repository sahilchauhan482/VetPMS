namespace VetPMS.Application.Commands.Patients.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletePatientCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeletePatientCommandHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<DeletePatientCommandResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==request.Id && x.ClinicId==request.ClinicId, cancellationToken) ?? throw new InvalidOperationException("Patient not found.");
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeletePatientCommandResponse(true);
        }
    }
}
