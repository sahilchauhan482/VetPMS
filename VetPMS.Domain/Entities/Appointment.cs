namespace VetPMS.Domain.Entities
{
    public class Appointment(int ownerId, int breedId,int clinicId, string services, string title, string email,string phone,
                      DateTime? start = null, DateTime? end = null,
                      string? comments = null, bool reminder = false)
    {
        public int Id { get; set; }
        public int OwnerId { get; set; } = ownerId;
        public int BreedId { get; set; } = breedId;
        public int ClinicId { get; set; } = clinicId;
        public DateTime? Start { get; set; } = start;
        public DateTime? End { get; set; } = end;
        public string Services { get; set; } = services;
        public string Title { get; set; } = title;
        public string? Comments { get; set; } = comments;
        public bool Reminder { get; set; } = reminder;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public Owner? Owner { get; set; }
        public Breed? Breed { get; set; }
        public Clinic? Clinic { get; set; }

        

        public void UpdateAppointmentDetails(int ownerId,int breedId, DateTime? start, DateTime? end, string services,
                                             string title, string? comments, bool reminder,string email,string phone)
        {
            OwnerId = ownerId;
            BreedId = breedId;
            Start = start;
            End = end;
            Services = services;
            Title = title;
            Comments = comments;
            Reminder = reminder;
            Email = email;
            Phone = phone;
        }
    }
}
