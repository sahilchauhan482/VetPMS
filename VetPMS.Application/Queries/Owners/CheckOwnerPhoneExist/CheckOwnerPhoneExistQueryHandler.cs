
using VetPMS.Application.Queries.UserRegister.CheckPhoneExist;

namespace VetPMS.Application.Queries.Owners.CheckOwnerPhoneExist
{
    public class CheckOwnerPhoneExistQueryHandler : IRequestHandler<CheckOwnerPhoneExistQuery, CheckOwnerPhoneExistQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public CheckOwnerPhoneExistQueryHandler(ApplicationDbContext context) => (_context) = (context);
        public async Task<CheckOwnerPhoneExistQueryResponse> Handle(CheckOwnerPhoneExistQuery request, CancellationToken cancellationToken)
        {
            var phoneExist = await _context.Owners.FirstOrDefaultAsync(e => e.PhoneNumber == request.PhoneNumber,cancellationToken);
            if (phoneExist != null) return new CheckOwnerPhoneExistQueryResponse(true);
            else return new CheckOwnerPhoneExistQueryResponse(false);
        }
    }
}
