using VetPMS.Application.Commands.Medicines.CreateMedicine;
using VetPMS.Application.Commands.Medicines.ExcelImport.BulkCreateMedicine;
using VetPMS.Domain.DTOs;

public class BulkCreateMedicineCommandHandler : IRequestHandler<BulkCreateMedicineCommand, List<CreateMedicineCommandResponse>>
{
    private readonly ApplicationDbContext _context;
   

    public BulkCreateMedicineCommandHandler(ApplicationDbContext context)=> (_context) = (context);

    public async Task<List<CreateMedicineCommandResponse>> Handle(BulkCreateMedicineCommand request, CancellationToken cancellationToken)
    {
        var responseList = new List<CreateMedicineCommandResponse>();

        var existingMedicines = await _context.Medicines
            .ToDictionaryAsync(m => (m.Name, m.Brand, m.ManufacturingDate), cancellationToken);

        foreach (var medicineCommand in request.Medicines)
        {
            var key = (medicineCommand.Name, medicineCommand.Brand, medicineCommand.ManufacturingDate);

            if (existingMedicines.TryGetValue(key, out var existingMedicine))
            {
                
                existingMedicine.UpdateMedicineDetails(
                    medicineCommand.Name,
                    medicineCommand.Brand,
                    medicineCommand.Description,
                    medicineCommand.MedicineType,
                    medicineCommand.Price,
                    medicineCommand.Unit,
                    medicineCommand.Quantity,
                    medicineCommand.Manufacturer,
                    medicineCommand.SupplierName,
                    medicineCommand.ManufacturingDate,
                    medicineCommand.ExpiryDate
                );

               
                responseList.Add(new CreateMedicineCommandResponse((MedicineDto)existingMedicine));
            }
            else
            {
                
                var newMedicine = new Medicine(
                    medicineCommand.Name,
                    medicineCommand.Brand,
                    medicineCommand.Description,
                    medicineCommand.MedicineType,
                    medicineCommand.Price,
                    medicineCommand.Unit,
                    medicineCommand.Quantity,
                    medicineCommand.Manufacturer,
                    medicineCommand.SupplierName,
                    medicineCommand.ManufacturingDate,
                    medicineCommand.ExpiryDate,
                    medicineCommand.ClinicId
                );

                _context.Medicines.Add(newMedicine);
                responseList.Add(new CreateMedicineCommandResponse((MedicineDto)newMedicine));
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        return responseList;
    }
}
