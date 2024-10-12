using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Appointments.GetAllAppointments
{
    public class GetAllAppointmentsCommandHandler : IRequestHandler<GetAllAppointmentsQuery, GetAllAppointmentsQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAppointmentsCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<GetAllAppointmentsQueryResponse> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            
            var appointments = await _context.Appointments.Where(x=>x.ClinicId==request.ClinicId)
                .Include(a => a.Owner)
                .Include(a => a.Breed)
                .ToListAsync(cancellationToken);
            var appointmentDto = appointments.Select(a => (AppointmentDto)a).ToList();

            return new GetAllAppointmentsQueryResponse(appointmentDto);
        }
    }
}
