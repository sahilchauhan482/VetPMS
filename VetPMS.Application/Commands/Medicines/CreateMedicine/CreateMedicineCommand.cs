namespace VetPMS.Application.Commands.Medicines.CreateMedicine
{
    public class CreateMedicineCommand:IRequest<CreateMedicineCommandResponse>
    {
        public required string Name { get; set; }

        public required string Brand { get; set; }

        public required string Description { get; set; }

        public required string MedicineType { get; set; }

        public decimal Price { get; set; }

        public required string Unit { get; set; }

        public int Quantity { get; set; }
        public int ClinicId { get; set; }
        public required string Manufacturer { get; set; }

        public required string SupplierName { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}
