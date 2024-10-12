using Microsoft.AspNetCore.Authorization;
using VetPMS.Application.Commands.Clinics.CreateClinic;
using VetPMS.Application.Commands.Clinics.DeleteClinic;
using VetPMS.Application.Commands.Clinics.UpdateClinic;
using VetPMS.Application.Queries.Clinics.GetClinicById;
using VetPMS.Application.Queries.Clinics.GetAllClinics;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ClinicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClinicController(IMediator mediator) => (_mediator) = (mediator);

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetClinicByIdQuery { Id = id });
            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllClinicsQuery());
            return Ok(response);
        }

        [HttpPost("CreateClinic")]
        public async Task<IActionResult> CreateClinic(CreateClinicCommand request)
        {
            var createResponse = await _mediator.Send(request);
            return Ok(createResponse);
        }

        [HttpPut("UpdateClinic/{id:int}")]
        public async Task<IActionResult> UpdateClinic(int id, UpdateClinicCommand request)
        {
            if (id != request.Id)
                return BadRequest("Mismatched Clinic ID");

            var updateResponse = await _mediator.Send(request);
            return Ok(updateResponse);
        }

        [HttpDelete("DeleteClinic/{id:int}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            var deleteResponse = await _mediator.Send(new DeleteClinicCommand { Id = id });
            return Ok(deleteResponse);
        }
    }
}
