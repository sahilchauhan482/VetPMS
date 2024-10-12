using VetPMS.Application.Commands.Medicines.CreateMedicine;
using VetPMS.Application.Commands.Medicines.ExcelImport.ReadMedicinesFromExcel;

namespace VetPMS.Application.Commands.Medicines.ReadMedicinesFromExcel
{
    public class ReadMedicinesFromExcelCommandHandler : IRequestHandler<ReadMedicinesFromExcelCommand, List<CreateMedicineCommand>>
    {
        public async Task<List<CreateMedicineCommand>> Handle(ReadMedicinesFromExcelCommand request, CancellationToken cancellationToken)
        {
            using var stream = new MemoryStream();
            await request.ExcelFile.CopyToAsync(stream, cancellationToken);

            using var workbook = new ClosedXML.Excel.XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1); 
            var medicines = new List<CreateMedicineCommand>();

            foreach (var row in worksheet.RowsUsed().Skip(1)) 
            {
                var medicine = new CreateMedicineCommand
                {
                    Name = row.Cell(1).GetValue<string>(),
                    Brand = row.Cell(2).GetValue<string>(),
                    Description = row.Cell(3).GetValue<string>(),
                    MedicineType = row.Cell(4).GetValue<string>(),
                    Price = row.Cell(5).GetValue<decimal>(),
                    Unit = row.Cell(6).GetValue<string>(),
                    Quantity = row.Cell(7).GetValue<int>(),
                    Manufacturer = row.Cell(8).GetValue<string>(),
                    SupplierName = row.Cell(9).GetValue<string>(),
                    ManufacturingDate = row.Cell(10).GetValue<DateTime>(),
                    ExpiryDate = row.Cell(11).GetValue<DateTime>(),
                    ClinicId=row.Cell(12).GetValue<int>(),
                };

                medicines.Add(medicine);
            }

            return medicines;
        }
    }
}
