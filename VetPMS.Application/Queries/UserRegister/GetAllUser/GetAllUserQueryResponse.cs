using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.UserRegister.GetAllUser
{
    public record GetAllUserQueryResponse(List<RegisterDto> RegisterDTO);

}
