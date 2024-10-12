using Microsoft.AspNetCore.Hosting;
using VetPMS.Infrastructure.Email;
using VetPMS.Infrastructure.SMS;

namespace VetPMS.Application.Commands.Appointments.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentCommandResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        public CreateAppointmentCommandHandler(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, EmailService emailService,SmsService smsService) =>
            (_context, _webHostEnvironment, _emailService,_smsService) = (context, webHostEnvironment, emailService,smsService);

        public async Task<CreateAppointmentCommandResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment(
                ownerId: request.OwnerId,
                breedId: request.BreedId,
                services: request.Services,
                title: request.Title,
                email: request.Email,
                phone: request.Phone,
                start: request.Start,
                end: request.End,
                comments: request.Comments,
                reminder: request.Reminder,
                clinicId:request.ClinicId
            );

            await _context.Appointments.AddAsync(appointment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

           
            try
            {
                var owner = await _context.Owners.FirstOrDefaultAsync(o=>o.Id == request.OwnerId)?? throw new KeyNotFoundException();
                var breed = await _context.Breeds.FirstOrDefaultAsync(o=>o.Id == request.BreedId)?? throw new KeyNotFoundException();
                string subject = "Your VetPMS Appointment is Confirmed! 🐾";
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "AppointmentContext", "Appointment.html");
                var emailContent = await File.ReadAllTextAsync(filePath);

                emailContent = emailContent.Replace("{FullName}", owner.Name ?? "N/A")
                               .Replace("{Title}", appointment.Title ?? "N/A")
                               .Replace("{StartDate}", appointment.Start?.ToString("MMMM dd, yyyy") ?? "N/A")
                               .Replace("{StartTime}", appointment.Start?.ToString("hh:mm tt") ?? "N/A")
                               .Replace("{EndTime}", appointment.End?.ToString("hh:mm tt") ?? "N/A")
                               .Replace("{Services}", appointment.Services ?? "N/A")
                               .Replace("{Comments}", appointment.Comments ?? "No comments")
                               .Replace("{Breed}", breed.Name ?? "N/A")
                               .Replace("{Email}", appointment.Email ?? "N/A")
                               .Replace("{Phone}", appointment.Phone ?? "N/A");

                await _emailService.SendEmailAsync(request.Email, subject, emailContent);
                await _smsService.SendSmsAsync(appointment.Phone!, emailContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
            }

            return new CreateAppointmentCommandResponse("Appointment created successfully.");
        }
    }
}
