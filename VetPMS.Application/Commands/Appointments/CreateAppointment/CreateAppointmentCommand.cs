namespace VetPMS.Application.Commands.Appointments.CreateAppointment
{
    public class CreateAppointmentCommand:IRequest<CreateAppointmentCommandResponse>
    {
        public required int OwnerId { get; set; }
        public required int BreedId { get; set; }
        public required int ClinicId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public required string Services { get; set; }
        public required string Title { get; set; }
        public string? Comments { get; set; }
        public bool Reminder { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
