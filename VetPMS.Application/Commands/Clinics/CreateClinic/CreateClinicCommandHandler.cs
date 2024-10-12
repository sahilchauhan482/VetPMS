using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Clinics.CreateClinic
{
    public class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, CreateClinicCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateClinicCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<CreateClinicCommandResponse> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Data cannot be null");

            var clinic = new Clinic(
                request.ClinicName, request.ClinicEmail, request.ClinicPhone, request.ClinicAddress, request.EstablishedDate);

            _context.Add(clinic);
            await _context.SaveChangesAsync(cancellationToken);

            var dto = (ClinicDto)clinic;
            return new CreateClinicCommandResponse(dto);
        }
    }
}
