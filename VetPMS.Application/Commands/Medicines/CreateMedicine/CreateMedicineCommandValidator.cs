using FluentValidation;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Medicines.CreateMedicine
{
    class CreateMedicineCommandValidator: AbstractValidator<MedicineDto>
    {
        public CreateMedicineCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Medicine Name is required.")
                .Length(1, 100).WithMessage("Medicine Name must be between 1 and 100 characters.");

            RuleFor(m => m.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .Length(1, 50).WithMessage("Brand must be between 1 and 50 characters.");

            RuleFor(m => m.Description)
                .Length(0, 250).WithMessage("Description must be up to 250 characters.");
            RuleFor(m => m.Unit)
               .Length(0, 250).WithMessage("Medicine Name is required.");

            RuleFor(m => m.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(m => m.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(m => m.Manufacturer)
                .NotEmpty().WithMessage("Manufacturer is required.");

            RuleFor(m => m.SupplierName)
                .NotEmpty().WithMessage("Supplier Name is required.");

            RuleFor(m => m.ManufacturingDate)
                .NotEmpty().WithMessage("Manufacturing Date is required.");

            RuleFor(m => m.ExpiryDate)
                .NotEmpty().WithMessage("Expiry Date is required.")
                .GreaterThan(m => m.ManufacturingDate)
                .WithMessage("Expiry Date must be after Manufacturing Date.");
        }
    }
}
