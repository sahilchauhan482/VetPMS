namespace VetPMS.Application.Commands.Medicines.DeleteMedicine
{
    public class DeleteMedicineCommand:IRequest<DeleteMedicineCommandResponse>
    {
        public int MedicineId { get; set; }
        public int ClinicId { get; set; }
    }
}
