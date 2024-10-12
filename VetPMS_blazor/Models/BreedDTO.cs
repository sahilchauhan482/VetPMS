namespace VetPMS.Models
{
    public class BreedDTO
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
    }

    public class BreedResponse
    {
        public List<BreedDTO> breedDTO { get; set; } = new List<BreedDTO>();
    }
}
