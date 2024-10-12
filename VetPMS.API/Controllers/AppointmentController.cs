using Microsoft.AspNetCore.Authorization;
using VetPMS.Application.Commands.Appointments.CreateAppointment;
using VetPMS.Application.Commands.Appointments.DeleteAppointment;
using VetPMS.Application.Commands.Appointments.UpdateAppointment;
using VetPMS.Application.Queries.Appointments.GetAllAppointments;
using VetPMS.Application.Queries.Appointments.GetAppointment;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Clinic")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator) => (_mediator) = (mediator);

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetAppointmentQuery { Id = id, ClinicId = clinicId });
            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetAllAppointmentsQuery { ClinicId = clinicId });
            return Ok(response);
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand request, [FromHeader] int clinicId)
        {
            request.ClinicId = clinicId;
            var createResponse = await _mediator.Send(request);
            return Ok(createResponse);
        }

        [HttpPut("UpdateAppointment/{id:int}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentCommand request, [FromHeader] int clinicId)
        {
            if (id != request.Id)
                return BadRequest("Mismatched Appointment ID");

            request.ClinicId = clinicId;
            var updateResponse = await _mediator.Send(request);
            return Ok(updateResponse);
        }

        [HttpDelete("DeleteAppointment/{id:int}")]
        public async Task<IActionResult> DeleteAppointment(int id, [FromHeader] int clinicId)
        {
            var deleteResponse = await _mediator.Send(new DeleteAppointmentCommand { Id = id, ClinicId = clinicId });
            return Ok(deleteResponse);
        }
    }
}
