using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Appointments.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAppointmentCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<UpdateAppointmentCommandResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            var appointment = await _context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Breed)
                .FirstOrDefaultAsync(a => a.Id == request.Id && a.ClinicId==request.ClinicId, cancellationToken)?? 
                throw new KeyNotFoundException($"Appointment with ID {request.Id} not found.");

            appointment.UpdateAppointmentDetails(
                request.OwnerId,
                request.BreedId,
                request.Start,
                request.End,
                request.Services,
                request.Title,
                request.Comments,
                request.Reminder,
                request.Email,
                request.Phone
            );
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync(cancellationToken);

            var appointmentDto = (AppointmentDto)appointment;
            return new UpdateAppointmentCommandResponse(appointmentDto);
        }
    }
}
