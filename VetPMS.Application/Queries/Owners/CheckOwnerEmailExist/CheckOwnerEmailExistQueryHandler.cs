using VetPMS.Application.Queries.UserRegister.CheckEmailExist;

namespace VetPMS.Application.Queries.Owners.CheckOwnerEmailExist
{
    public class CheckOwnerEmailExistQueryHandler : IRequestHandler<CheckOwnerEmailExistQuery, CheckOwnerEmailExistQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public CheckOwnerEmailExistQueryHandler(ApplicationDbContext context) => (_context) = (context);
        public async Task<CheckOwnerEmailExistQueryResponse> Handle(CheckOwnerEmailExistQuery request, CancellationToken cancellationToken)
        {
            var emailExist = await _context.Owners.FirstOrDefaultAsync(e => e.Email == request.Email,cancellationToken);
            if (emailExist != null) return new CheckOwnerEmailExistQueryResponse(true);
            else return new CheckOwnerEmailExistQueryResponse(false);
        }
    }
}
