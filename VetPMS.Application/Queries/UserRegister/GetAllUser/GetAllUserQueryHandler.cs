using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.UserRegister.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUserQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync(cancellationToken) ?? throw new KeyNotFoundException();
            var dto = users.OfType<Register>().Select(user => (RegisterDto)user).ToList();
            return new GetAllUserQueryResponse(dto);
        }
    }
}
