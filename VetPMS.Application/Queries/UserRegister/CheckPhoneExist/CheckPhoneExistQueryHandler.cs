namespace VetPMS.Application.Queries.UserRegister.CheckPhoneExist
{
    public class CheckPhoneExistQueryHandler : IRequestHandler<CheckPhoneExistQuery, CheckPhoneExistQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public CheckPhoneExistQueryHandler(ApplicationDbContext context) => (_context) = (context);
        public async Task<CheckPhoneExistQueryResponse> Handle(CheckPhoneExistQuery request, CancellationToken cancellationToken)
        {
            var phoneExist = await _context.Registers.FirstOrDefaultAsync(e => e.PhoneNumber == request.PhoneNumber , cancellationToken);
            if (phoneExist != null) return new CheckPhoneExistQueryResponse(true);
            else return new CheckPhoneExistQueryResponse(false);
        }
    }
}
