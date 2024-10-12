namespace VetPMS.Application.Queries.Appointments.GetAppointment
{
    public class GetAppointmentQuery : IRequest<GetAppointmentQueryResponse>
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
