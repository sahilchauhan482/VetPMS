namespace VetPMS.Application.Commands.Clinics.DeleteClinic
{
    public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteClinicCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _context.Clinics.FindAsync(request.Id);

            if (clinic == null)
                throw new KeyNotFoundException($"Clinic with ID {request.Id} not found.");

            _context.Clinics.Remove(clinic);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
