using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Appointments.GetAllAppointments
{
    public record GetAllAppointmentsQueryResponse(List<AppointmentDto> AppointmentDTO);
    
    
}
