using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Owners.GetAllOwners
{
    public record GetAllOwnersQueryResponse(List<OwnerDto> OwnerDTO);
   
}
