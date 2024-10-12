using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Appointments.GetAppointment
{
    public class GetAppointmentCommandHandler : IRequestHandler<GetAppointmentQuery, GetAppointmentQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAppointmentCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<GetAppointmentQueryResponse> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Breed)
                .FirstOrDefaultAsync(a => a.Id == request.Id && a.ClinicId==request.ClinicId, cancellationToken);

            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {request.Id} not found.");
            }

            var appointmentDto = (AppointmentDto)appointment;

            return new GetAppointmentQueryResponse(appointmentDto);
        }
    }
}
