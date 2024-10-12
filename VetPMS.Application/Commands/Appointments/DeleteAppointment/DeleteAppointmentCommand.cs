namespace VetPMS.Application.Commands.Appointments.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<DeleteAppointmentCommandResponse>
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
