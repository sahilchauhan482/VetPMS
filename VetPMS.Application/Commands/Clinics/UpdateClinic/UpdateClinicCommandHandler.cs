using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Clinics.UpdateClinic
{
    public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand, UpdateClinicCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateClinicCommandHandler(ApplicationDbContext context) => _context = context;

        public async Task<UpdateClinicCommandResponse> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _context.Clinics.FindAsync(request.Id);

            if (clinic == null)
                throw new KeyNotFoundException($"Clinic with ID {request.Id} not found.");

            clinic.UpdateClinicDetails(
                request.ClinicName, request.ClinicEmail, request.ClinicPhone, request.ClinicAddress, request.EstablishedDate);

            await _context.SaveChangesAsync(cancellationToken);

            var dto = (ClinicDto)clinic;
            return new UpdateClinicCommandResponse(dto);
        }
    }
}
