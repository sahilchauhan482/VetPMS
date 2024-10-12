using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Breed.GetAllBreeds
{
    public record GetAllBreedsQueryResponse(List<BreedDto> BreedDTO);
   
}
