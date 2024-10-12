namespace VetPMS.Application.Commands.Breeds.CreateBreed
{
    using global::VetPMS.Domain.DTOs;

    namespace VetPMS.Application.Command.Breeds.CreateBreed
    {
        public class CreateBreedCommandHandler : IRequestHandler<CreateBreedCommand, CreateBreedCommandResponse>
        {
            private readonly ApplicationDbContext _context;

            public CreateBreedCommandHandler(ApplicationDbContext context) => (_context) = (context);

            public async Task<CreateBreedCommandResponse> Handle(CreateBreedCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Origin))
                {
                    throw new ArgumentException("Name or Origin is empty. Please provide valid data.");
                }

                var breed =new Breed(request.Name,request.Origin,request.ClinicId);
                _context.Add(breed);
                await _context.SaveChangesAsync(cancellationToken);
                BreedDto dto = (BreedDto)breed;
                return new CreateBreedCommandResponse(dto);
            }
        }
    }

}
