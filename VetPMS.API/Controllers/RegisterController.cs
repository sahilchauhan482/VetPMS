using Microsoft.AspNetCore.Authorization;
using VetPMS.Application.Commands.Registers;
using VetPMS.Application.Queries.UserRegister.CheckEmailExist;
using VetPMS.Application.Queries.UserRegister.CheckPhoneExist;
using VetPMS.Application.Queries.UserRegister.GetAllUser;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _Mediator;
        public RegisterController(IMediator Mediator) =>(_Mediator)=(Mediator);
        
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRegisterCommand Request)
        {
            ArgumentNullException.ThrowIfNull(Request);
            var result = await _Mediator.Send(Request);
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]

        public async Task<IActionResult>Get()
        {
            var result = await _Mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }


        [HttpGet("CheckEmailExists")]
        public async Task<IActionResult> CheckEmailExists(string Email, int clinicId)
        {
            
            var result = await _Mediator.Send(new CheckEmailExistQuery { Email = Email,ClinicId=clinicId });
            return Ok(result);
        }

        [HttpGet("CheckPhoneNumberExists")]
        public async Task<IActionResult> CheckPhoneNumberExists(string phoneNumber,int clinicId)
        {
            var result = await _Mediator.Send(new CheckPhoneExistQuery { PhoneNumber = phoneNumber, ClinicId = clinicId });
            return Ok(result);
        }
    }


}
