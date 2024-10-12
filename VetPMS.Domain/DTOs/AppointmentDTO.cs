using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int BreedId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public required string Services { get; set; }
        public required string Title { get; set; }      
        public required string? Comments { get; set; }
        public bool Reminder { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public OwnerDto? Owner { get; set; }
        public BreedDto? Breed { get; set; }


        public static explicit operator AppointmentDto(Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                OwnerId = appointment.OwnerId,
                BreedId = appointment.BreedId,
                Start = appointment.Start,
                End = appointment.End,
                Services = appointment.Services,
                Title = appointment.Title,
                Comments = appointment.Comments,
                Reminder = appointment.Reminder,
                Email = appointment.Email,
                Phone = appointment.Phone,
                Owner = appointment.Owner != null ? (OwnerDto)appointment.Owner : null,
                Breed = appointment.Breed != null ? (BreedDto)appointment.Breed : null
            };
        }
    }
}
