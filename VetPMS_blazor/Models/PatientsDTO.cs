namespace VetPMS.Models
{
    public class PatientsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreedId { get; set; }
        public int ClinicId { get; set; }
        public string BreedName { get; set; }
        public DateTime? DOB { get; set; }
        public string Colour { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public OwnerDTO? Owner { get; set; }
        public BreedDTO? Breed { get; set; }

    }

    public class PatientResponse
    {
        public List<PatientsDTO> PatientDTO { get; set; } = new List<PatientsDTO>();
    }

    public class GetPatientResponse
    {
        public PatientsDTO PatientDTO { get; set; }
    }
}
