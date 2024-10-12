using Microsoft.AspNetCore.Authorization;
using VetPMS.Application.Commands.Owners.DeleteOwner;
using VetPMS.Application.Commands.Owners.UpdateOwner;
using VetPMS.Application.Queries.Owners.CheckOwnerEmailExist;
using VetPMS.Application.Queries.Owners.CheckOwnerPhoneExist;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Clinic")]
public class OwnerController : ControllerBase
{
    private readonly IMediator _mediator;

    public OwnerController(IMediator mediator) => (_mediator) = (mediator);

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, int? clinicId) 
    {
        var response = await _mediator.Send(new GetOwnerQuery { Id = id, ClinicId = clinicId });
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int? clinicId) 
    {
        var response = await _mediator.Send(new GetAllOwnersQuery { ClinicId = clinicId });
        return Ok(response);
    }

    [HttpPost("CreateOwner")]
    public async Task<IActionResult> CreateOwner(CreateOwnerCommand request, int? clinicId) 
    {
        request.ClinicId = clinicId; 
        var createResponse = await _mediator.Send(request);
        return Ok(createResponse);
    }

    [HttpPut("UpdateOwner/{id:int}")]
    public async Task<IActionResult> UpdateOwner(int id, UpdateOwnerCommand request, int? clinicId) 
    {
        if (id != request.Id)
            return BadRequest("Mismatched Owner ID");

        request.ClinicId = clinicId; 
        var updateResponse = await _mediator.Send(request);
        return Ok(updateResponse);
    }

    [HttpDelete("DeleteOwner/{id:int}")]
    public async Task<IActionResult> DeleteOwner(int id, int? clinicId) 
    {
        var deleteResponse = await _mediator.Send(new DeleteOwnerCommand { Id = id, ClinicId = clinicId }); 
        return Ok(deleteResponse);
    }

    [HttpGet("CheckEmailExists")]
    public async Task<IActionResult> CheckEmailExists(string email, int? clinicId) 
    {
        var result = await _mediator.Send(new CheckOwnerEmailExistQuery { Email = email, ClinicId = clinicId });
        return Ok(result);
    }

    [HttpGet("CheckPhoneNumberExists")]
    public async Task<IActionResult> CheckPhoneNumberExists(string phoneNumber, int? clinicId) 
    {
        var result = await _mediator.Send(new CheckOwnerPhoneExistQuery { PhoneNumber = phoneNumber, ClinicId = clinicId }); 
        return Ok(result);
    }
}
