using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class BreedDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Origin { get; set; }

        public static explicit operator BreedDto(Breed breed)
        {
            return new BreedDto
            {
                Id = breed.Id,
                Name = breed.Name,
                Origin = breed.Origin
            };
        }
    }
}
