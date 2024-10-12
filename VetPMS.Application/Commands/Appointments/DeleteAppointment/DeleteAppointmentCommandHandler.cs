namespace VetPMS.Application.Commands.Appointments.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, DeleteAppointmentCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteAppointmentCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<DeleteAppointmentCommandResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == request.Id && a.ClinicId==request.ClinicId, cancellationToken);

            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {request.Id} not found.");
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteAppointmentCommandResponse(true);
        }
    }
}
