using VetPMS.Application.Commands.Account.Authentication;
using VetPMS.Application.Commands.Account.ResetPassword;
using VetPMS.Application.Commands.Account.ResetPasswordToken;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator) => (_mediator) = (mediator);

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(CreateLoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("GenerateResetPasswordToken")]
        public async Task<IActionResult> GenerateResetPasswordToken([FromBody] ResetPasswordTokenGenerateCommand command)
        {
           var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand createResetPasswordCommand)
        {
            var result = await _mediator.Send(createResetPasswordCommand);
            return Ok(result);
        }

    }
}
