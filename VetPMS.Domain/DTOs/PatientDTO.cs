using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int BreedId { get; set; }
        public required DateTime DOB { get; set; }
        public required string Colour { get; set; }
        public int OwnerId { get; set; }
        public OwnerDto? Owner { get; set; }
        public BreedDto? Breed { get; set; }

        

        public static explicit operator PatientDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                BreedId = patient.BreedId,
                DOB = patient.DOB,
                Colour = patient.Colour,
                OwnerId = patient.OwnerId,
                Owner= patient.Owner != null ? (OwnerDto)patient.Owner : null,
                Breed= patient.Breed != null ? (BreedDto)patient.Breed : null
            };
        }
    }
}
