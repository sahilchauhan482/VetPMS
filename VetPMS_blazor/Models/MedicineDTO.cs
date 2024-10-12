namespace VetPMS.Models
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public int ClinicId { get; set; }
        public  string Name { get; set; } = string.Empty;

        public  string Brand { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string MedicineType { get; set; } = string.Empty;

        public decimal Price { get; set; } 

        public string Unit { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public  string Manufacturer { get; set; } = string.Empty;

        public  string SupplierName { get; set; } = string.Empty;

        public DateTime? ManufacturingDate { get; set; } = null;

        public DateTime? ExpiryDate { get; set; } = null;
    }



    public class MedicineResponse
    {
        public List<MedicineDTO> MedicineDTO { get; set; } = new List<MedicineDTO>();
    }

    public class GetMedicineResponse
    {
        public MedicineDTO MedicineDTO { get; set; }
    }
}
