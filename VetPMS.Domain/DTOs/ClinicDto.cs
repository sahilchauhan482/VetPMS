using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public required string ClinicName { get; set; }
        public required string ClinicEmail { get; set; }
        public required string ClinicPhone { get; set; }
        public required string ClinicAddress { get; set; }
        public DateTime EstablishedDate { get; set; }

        public static explicit operator ClinicDto(Clinic clinic)
        {
            return new ClinicDto
            {
                ClinicId = clinic.Id,
                ClinicName = clinic.ClinicName,
                ClinicEmail = clinic.ClinicEmail,
                ClinicPhone = clinic.ClinicPhone,
                ClinicAddress = clinic.ClinicAddress,
                EstablishedDate = clinic.EstablishedDate
            };
        }
    }
}
