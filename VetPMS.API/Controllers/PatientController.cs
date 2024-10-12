using Microsoft.AspNetCore.Authorization;
using VetPMS.Application.Commands.Patients.CreatePatient;
using VetPMS.Application.Commands.Patients.DeletePatient;
using VetPMS.Application.Commands.Patients.UpdatePatient;
using VetPMS.Application.Query.Patients.GetAllPatients;
using VetPMS.Application.Query.Patients.GetPatient;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Clinic")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator) => (_mediator) = (mediator);

        [HttpPost("createPatient")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand request, [FromHeader] int clinicId)
        {
            request.ClinicId = clinicId; 
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("updatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientCommand request, [FromHeader] int clinicId)
        {
            if (id != request.Id) return BadRequest("Mismatched Patient ID");
            request.ClinicId = clinicId; 
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("deletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new DeletePatientCommand { Id = id, ClinicId = clinicId });
            return Ok(response);
        }

        [HttpGet("getPatient/{id}")]
        public async Task<IActionResult> GetPatient(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetPatientQuery { Id = id, ClinicId = clinicId });
            return Ok(response);
        }

        [HttpGet("getAllPatients")]
        public async Task<IActionResult> GetAllPatients([FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetAllPatientsQuery { ClinicId = clinicId });
            return Ok(response);
        }
    }
}
