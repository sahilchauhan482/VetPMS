using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Owners.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, UpdateOwnerCommandResponse>
    {
        private readonly ApplicationDbContext _context;
        public UpdateOwnerCommandHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<UpdateOwnerCommandResponse> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners
            .FirstOrDefaultAsync(o => o.Id == request.Id && o.ClinicId==request.ClinicId, cancellationToken) ?? throw new KeyNotFoundException($"Owner with ID {request.Id} not found.");
             owner.OwnerUpdateDetails(request.Name, request.Address, request.PhoneNumber, request.Email);
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync(cancellationToken);
            OwnerDto dto = (OwnerDto)owner;

            return new UpdateOwnerCommandResponse(dto);
        }
    }
}
