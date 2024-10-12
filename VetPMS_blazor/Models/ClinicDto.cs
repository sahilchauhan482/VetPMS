namespace VetPMS.Models
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicEmail { get; set; }
        public string ClinicPhone { get; set; }
        public string ClinicAddress { get; set; }
        public DateTime? EstablishedDate { get; set; }
    }

    public class ClinicResponse
    {
        public List<ClinicDto> ClinicDto { get; set; } = new List<ClinicDto>();
    }

    public class GetClinicResponse
    {
        public ClinicDto ClinicDto { get; set; }
    }
}
