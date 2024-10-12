using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Medicines.CreateMedicine
{
    public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommand, CreateMedicineCommandResponse>
    {
        private readonly ApplicationDbContext _context;
        public CreateMedicineCommandHandler(ApplicationDbContext context) => (_context) = (context);
        public async Task<CreateMedicineCommandResponse> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var medicine = new Medicine(
               request.Name,
               request.Brand,
               request.Description,
               request.MedicineType,
               request.Price,
               request.Unit,
               request.Quantity,
               request.Manufacturer,
               request.SupplierName,
               request.ManufacturingDate,
               request.ExpiryDate,
               request.ClinicId
              
           );

            _context.Add(medicine);
            await _context.SaveChangesAsync(cancellationToken);

            MedicineDto dto = (MedicineDto)medicine;

            return new CreateMedicineCommandResponse(dto);
        }
    }
}
