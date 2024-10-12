namespace VetPMS.Application.Commands.Medicines.UpdateMedicine
{
    public class UpdateMedicineCommand:IRequest<UpdateMedicineCommandResponse>
    {
        public int MedicineId { get; set; }

        public required string Name { get; set; }

        public required string Brand { get; set; }

        public required string Description { get; set; }

        public required string MedicineType { get; set; }

        public required decimal Price { get; set; }

        public required string Unit { get; set; }

        public int Quantity { get; set; }

        public required string Manufacturer { get; set; }

        public required string SupplierName { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }
        public int ClinicId { get; set; }
    }
}
