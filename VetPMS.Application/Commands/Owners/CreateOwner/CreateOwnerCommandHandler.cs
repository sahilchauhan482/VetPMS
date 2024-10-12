using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Owners.CreateOwner
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, CreateOwnerResponse>
    {
        private readonly ApplicationDbContext _context;
        public CreateOwnerCommandHandler(ApplicationDbContext context)=>(_context)=(context);
        
        public async Task<CreateOwnerResponse> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Data cannot be null");

            if (string.IsNullOrEmpty(request.Name) ||
                string.IsNullOrEmpty(request.Address) ||
                string.IsNullOrEmpty(request.PhoneNumber) ||
                string.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentException("One or more fields are empty. Please provide valid data.");
            }
            var owner = new Owner(request.Name,request.Address,request.PhoneNumber,request.Email,request.ClinicId);
            _context.Add(owner);
            await _context.SaveChangesAsync(cancellationToken);
            OwnerDto dto = (OwnerDto)owner;
            return new CreateOwnerResponse(dto);
        }
    }
}

