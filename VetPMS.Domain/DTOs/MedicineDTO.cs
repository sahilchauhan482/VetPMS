using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class MedicineDto
    {
        public int MedicineId { get; set; }

        public required string Name { get; set; }

        public required string Brand { get; set; }

        public required string Description { get; set; }

        public required string MedicineType { get; set; }

        public decimal Price { get; set; }

        public required string Unit { get; set; }

        public int Quantity { get; set; }
        public required string Manufacturer { get; set; }

        public required string SupplierName { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }


        public static explicit operator MedicineDto(Medicine medicine)
        {
            return new MedicineDto
            {
                MedicineId = medicine.MedicineId,
                Name = medicine.Name,
                Brand = medicine.Brand,
                Description = medicine.Description,
                MedicineType = medicine.MedicineType,
                Price = medicine.Price,
                Unit = medicine.Unit,
                Quantity = medicine.Quantity,
                Manufacturer = medicine.Manufacturer,
                SupplierName = medicine.SupplierName,
                ManufacturingDate = medicine.ManufacturingDate,
                ExpiryDate = medicine.ExpiryDate,
            };
        }
    }
}
