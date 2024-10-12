namespace VetPMS.Application.Commands.Medicines.DeleteMedicine
{
    public class DeleteMedicineCommandHandler : IRequestHandler<DeleteMedicineCommand, DeleteMedicineCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteMedicineCommandHandler(ApplicationDbContext context) => (_context) = (context);
      

        public async Task<DeleteMedicineCommandResponse> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineId == request.MedicineId && m.ClinicId==request.ClinicId, cancellationToken)
                ?? throw new KeyNotFoundException($"Medicine with ID {request.MedicineId} not found.");

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteMedicineCommandResponse(true);
        }
    }
}
