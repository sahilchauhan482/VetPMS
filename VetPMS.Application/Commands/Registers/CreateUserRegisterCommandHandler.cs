using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using VetPMS.Domain.DTOs;
using VetPMS.Infrastructure.Email;

namespace VetPMS.Application.Commands.Registers
{
    public class CreateUserRegisterCommandHandler : IRequestHandler<CreateUserRegisterCommand, CreateUserRegisterResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailService _emailService;
        public CreateUserRegisterCommandHandler(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment, EmailService emailService) =>
            (_context, _userManager, _roleManager, _webHostEnvironment, _emailService) = (context, userManager, roleManager, webHostEnvironment, emailService);

        public async Task<CreateUserRegisterResponse> Handle(CreateUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var existingPhone = await _context.Registers.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
            if (existingPhone != null) throw new KeyNotFoundException("Phone Number has Already used by Someone");
            var existingEmail = await _context.Registers.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (existingEmail != null) throw new KeyNotFoundException("Email has Already used by Someone");

            var User = new Register
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                Gender = request.Gender,
                IsActive = true,
                ClinicId = request.ClinicId == 0 ? null : request.ClinicId,
                CreatedDateAndTime = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(User, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new KeyNotFoundException($"User could not be created. Errors: {errors}");
            }
            var roleExists = await _roleManager.RoleExistsAsync(request.Role);
            if (!roleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(request.Role));
                if (!roleResult.Succeeded)
                {
                    throw new KeyNotFoundException("Failed to create role.");
                }
            }
            var roleAssignResult = await _userManager.AddToRoleAsync(User,request.Role);
            if (!roleAssignResult.Succeeded)
            {
                throw new KeyNotFoundException("Failed to assign role.");
            }
            try
            {
                string subject = "Registration Email - VetPMS";
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "EmailContext", "EmailContent.txt");
                var emailContent = await File.ReadAllTextAsync(filePath);
                emailContent = emailContent.Replace("{FullName}", User.FullName)
                                           .Replace("{Email}", User.Email)
                                           .Replace("{UserName}", User.UserName);

                await _emailService.SendEmailAsync(User.Email, subject, emailContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
            }
            

            RegisterDto dto = (RegisterDto)User;
            return new CreateUserRegisterResponse(dto);
        }
    }
}
