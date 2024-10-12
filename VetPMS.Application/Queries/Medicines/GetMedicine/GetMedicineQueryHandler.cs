
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Medicines.GetMedicine
{
    public class GetMedicineQueryHandler : IRequestHandler<GetMedicineQuery, GetMedicineQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetMedicineQueryHandler(ApplicationDbContext context) => (_context) = context;
        public async Task<GetMedicineQueryResponse> Handle(GetMedicineQuery request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicines
                 .FirstOrDefaultAsync(m => m.MedicineId == request.MedicineId && m.ClinicId==request.ClinicId, cancellationToken)
                 ?? throw new KeyNotFoundException($"Medicine with ID {request.MedicineId} not found.");
            MedicineDto dto = (MedicineDto)medicine;
            return new GetMedicineQueryResponse(dto);
        }
    }
}
