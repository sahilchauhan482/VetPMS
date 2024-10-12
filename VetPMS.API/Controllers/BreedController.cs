using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetPMS.Application.Command.Breeds.DeleteBreed;
using VetPMS.Application.Command.Breeds.UpdateBreed;
using VetPMS.Application.Commands.Breeds.CreateBreed;
using VetPMS.Application.Queries.Breed.GetBreed;
using VetPMS.Application.Queries.Breed.GetAllBreeds;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Clinic")]
    public class BreedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BreedController(IMediator mediator) => (_mediator) = (mediator);

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetBreedQuery { Id = id, ClinicId = clinicId });
            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetAllBreedsQuery { ClinicId = clinicId });
            return Ok(response);
        }

        [HttpPost("CreateBreed")]
        public async Task<IActionResult> CreateBreed([FromBody] CreateBreedCommand request, [FromHeader] int clinicId)
        {
            request.ClinicId = clinicId;
            var createResponse = await _mediator.Send(request);
            return Ok(createResponse);
        }

        [HttpPut("UpdateBreed/{id:int}")]
        public async Task<IActionResult> UpdateBreed(int id, [FromBody] UpdateBreedCommand request, [FromHeader] int clinicId)
        {
            if (id != request.Id)
                return BadRequest("Mismatched Breed ID");

            request.ClinicId = clinicId;
            var updateResponse = await _mediator.Send(request);
            return Ok(updateResponse);
        }

        [HttpDelete("DeleteBreed/{id:int}")]
        public async Task<IActionResult> DeleteBreed(int id, [FromHeader] int clinicId)
        {
            var deleteResponse = await _mediator.Send(new DeleteBreedCommand { Id = id, ClinicId = clinicId });
            return Ok(deleteResponse);
        }
    }
}
