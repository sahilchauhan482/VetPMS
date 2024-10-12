

namespace VetPMS.Models
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }


    public class OwnerResponse
    {
        public List<OwnerDTO> OwnerDTO { get; set; } = new List<OwnerDTO>();
    }

    public class GetOwnerResponse
    {
        public OwnerDTO OwnerDTO { get; set; }
    }


}
