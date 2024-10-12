namespace VetPMS.Application.Queries.Appointments.GetAllAppointments
{
    public class GetAllAppointmentsQuery : IRequest<GetAllAppointmentsQueryResponse>
    {
        public int ClinicId { get; set; }
    }
}
