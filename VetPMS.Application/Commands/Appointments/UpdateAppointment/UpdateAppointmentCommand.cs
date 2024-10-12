namespace VetPMS.Application.Commands.Appointments.UpdateAppointment
{
    public class UpdateAppointmentCommand:IRequest<UpdateAppointmentCommandResponse>
    {
        public int Id { get; set; }
        public int OwnerId { get; set; } 
        public int ClinicId { get; set; } 
        public int BreedId { get; set; } 
        public DateTime? Start { get; set; } 
        public DateTime? End { get; set; } 
        public required string Services { get; set; } 
        public required string Title { get; set; }
        public required string? Comments { get; set; }
        public bool Reminder { get; set; } 
        public required string Email { get; set; } 
        public required string Phone { get; set; } 

    }
}
