using VetPMS.Application.Commands.Medicines.CreateMedicine;

namespace VetPMS.Application.Commands.Medicines.ExcelImport.BulkCreateMedicine
{
    public class BulkCreateMedicineCommand(List<CreateMedicineCommand> medicines) : IRequest<List<CreateMedicineCommandResponse>>
    {
        public List<CreateMedicineCommand> Medicines { get; set; } = medicines ?? new List<CreateMedicineCommand>();
    }
}
