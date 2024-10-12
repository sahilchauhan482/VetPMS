namespace VetPMS.Application.Commands.Owners.DeleteOwner
{
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, DeleteOwnerCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public DeleteOwnerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteOwnerCommandResponse> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners
                .FirstOrDefaultAsync(o => o.Id == request.Id && o.ClinicId==request.ClinicId, cancellationToken)?? throw new KeyNotFoundException($"Owner with ID {request.Id} not found.");
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteOwnerCommandResponse(true);
        }
    }
}
