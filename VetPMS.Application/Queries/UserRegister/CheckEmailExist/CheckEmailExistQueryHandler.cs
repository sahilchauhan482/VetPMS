namespace VetPMS.Application.Queries.UserRegister.CheckEmailExist
{
    public class CheckEmailExistQueryHandler : IRequestHandler<CheckEmailExistQuery, CheckEmailExistQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        public CheckEmailExistQueryHandler(ApplicationDbContext context) => (_context) = (context);

        public async Task<CheckEmailExistQueryResponse> Handle(CheckEmailExistQuery request, CancellationToken cancellationToken)
        {
            var emailExist = await _context.Registers.FirstOrDefaultAsync(e => e.Email == request.Email ,cancellationToken);
            if (emailExist != null) return new CheckEmailExistQueryResponse(true);
            else return new CheckEmailExistQueryResponse(false);
        }
    }
}
