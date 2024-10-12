using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetPMS.Application.Commands.Medicines.CreateMedicine;
using VetPMS.Application.Commands.Medicines.DeleteMedicine;
using VetPMS.Application.Commands.Medicines.ExcelImport.BulkCreateMedicine;
using VetPMS.Application.Commands.Medicines.ExcelImport.ReadMedicinesFromExcel;
using VetPMS.Application.Commands.Medicines.UpdateMedicine;
using VetPMS.Application.Queries.Medicines.GetAllMedicines;
using VetPMS.Application.Queries.Medicines.GetMedicine;

namespace VetPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Clinic")]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator) => (_mediator) = (mediator);

        [HttpPost("createMedicine")]
        public async Task<IActionResult> CreateMedicine([FromBody] CreateMedicineCommand request, [FromHeader] int clinicId)
        {
            request.ClinicId = clinicId; 
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("updateMedicine/{id}")]
        public async Task<IActionResult> UpdateMedicine(int id, [FromBody] UpdateMedicineCommand request, [FromHeader] int clinicId)
        {
            if (id != request.MedicineId) return BadRequest("Mismatched Medicine ID");
            request.ClinicId = clinicId; 
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("deleteMedicine/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new DeleteMedicineCommand { MedicineId = id, ClinicId = clinicId });
            return Ok(response);
        }

        [HttpGet("getMedicine/{id}")]
        public async Task<IActionResult> GetMedicine(int id, [FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetMedicineQuery { MedicineId = id, ClinicId = clinicId });
            return Ok(response);
        }

        [HttpGet("getAllMedicines")]
        public async Task<IActionResult> GetAllMedicines([FromHeader] int clinicId)
        {
            var response = await _mediator.Send(new GetAllMedicinesQuery { ClinicId = clinicId });
            return Ok(response);
        }

        [HttpPost("bulkCreateFromExcel")]
        public async Task<IActionResult> BulkCreateFromExcel(IFormFile file, [FromHeader] int clinicId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var readMedicinesQuery = new ReadMedicinesFromExcelCommand(file);
            var medicines = await _mediator.Send(readMedicinesQuery);

            var bulkCreateCommand = new BulkCreateMedicineCommand(medicines);
            var response = await _mediator.Send(bulkCreateCommand);

            return Ok(response);
        }
    }
}
