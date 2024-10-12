using System.ComponentModel.DataAnnotations.Schema;

namespace VetPMS.Domain.Entities
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public string MedicineType { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        public string Manufacturer { get; set; }

        public string SupplierName { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }


        public Medicine(
            string name, string brand, string description, string medicineType, decimal price,
            string unit, int quantity, string manufacturer, string supplierName,
            DateTime manufacturingDate, DateTime expiryDate,int clinicId) =>

            (Name, Brand, Description, MedicineType, Price, Unit, Quantity, Manufacturer,
            SupplierName, ManufacturingDate, ExpiryDate,CreatedDate,ClinicId) =
            (name, brand, description, medicineType, price, unit, quantity, manufacturer,
            supplierName, manufacturingDate, expiryDate,DateTime.Now,clinicId);

       
        public void UpdateMedicineDetails(
            string name, string brand, string description, string medicineType, decimal price,
            string unit, int quantity, string manufacturer, string supplierName,
            DateTime manufacturingDate, DateTime expiryDate)
        {
            Name = name;
            Brand = brand;
            Description = description;
            MedicineType = medicineType;
            Price = price;
            Unit = unit;
            Quantity = quantity;
            Manufacturer = manufacturer;
            SupplierName = supplierName;
            ManufacturingDate = manufacturingDate;
            ExpiryDate = expiryDate;
            UpdatedDate = DateTime.Now;
        }
    }
}
