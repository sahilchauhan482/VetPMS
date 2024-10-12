using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Medicines.GetAllMedicines
{
    public class GetAllMedicinesQueryHandler : IRequestHandler<GetAllMedicinesQuery, GetAllMedicinesQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllMedicinesQueryHandler(ApplicationDbContext context) => (_context) = context;

        public async Task<GetAllMedicinesQueryResponse> Handle(GetAllMedicinesQuery request, CancellationToken cancellationToken)
        {
            var medicines = await _context.Medicines.Where(x=>x.ClinicId==request.ClinicId).ToListAsync(cancellationToken);
            var dto = medicines.Select(medicine => (MedicineDto)medicine).ToList();
            return new GetAllMedicinesQueryResponse(dto);
        }
    }
}
