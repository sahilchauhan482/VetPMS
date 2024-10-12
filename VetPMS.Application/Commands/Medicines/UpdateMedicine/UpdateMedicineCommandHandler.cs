
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Medicines.UpdateMedicine
{
    public class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommand, UpdateMedicineCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateMedicineCommandHandler(ApplicationDbContext context) => (_context) = context;
        public async Task<UpdateMedicineCommandResponse> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineId == request.MedicineId && m.ClinicId==request.ClinicId, cancellationToken)
                ?? throw new KeyNotFoundException($"Medicine with ID {request.MedicineId} not found.");

            medicine.UpdateMedicineDetails(
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
                request.ExpiryDate
            );
            _context.Medicines.Update(medicine);
            await _context.SaveChangesAsync(cancellationToken);
            MedicineDto dto = (MedicineDto)medicine;
            return new UpdateMedicineCommandResponse(dto);
        }
    }
}
