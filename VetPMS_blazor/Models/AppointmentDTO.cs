namespace VetPMS.Models
{
    public class AppointmentDTO
    {
        public int Id { get; set; }      
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int BreedId { get; set; }
        public string BreedName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Services { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public bool Reminder { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public OwnerDTO? Owner { get; set; }
        public BreedDTO? Breed { get; set; }
    }

    public class AppointmentResponse
    {
        public List<AppointmentDTO> appointmentDTO { get; set; } = new List<AppointmentDTO>();
    }

    public class GetAppointmentResponse
    {
        public AppointmentDTO appointmentDTO { get; set; }
    }

}
