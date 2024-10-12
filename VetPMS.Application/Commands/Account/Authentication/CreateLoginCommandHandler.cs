using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Commands.Account.Authentication
{
    public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, CreateLoginCommandResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        
        private readonly SignInManager<IdentityUser> _signInManager;
        public CreateLoginCommandHandler(ApplicationDbContext context, IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        => (_context, _configuration, _userManager, _signInManager) = (context, configuration, userManager, signInManager);



        public async Task<CreateLoginCommandResponse> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.Email) ?? throw new UnauthorizedAccessException("Invalid credentials.");

            var userDetail = await _context.Registers.FirstOrDefaultAsync(u => u.UserName == request.Email, cancellationToken) ?? throw new KeyNotFoundException("UserName not found.");
            var clinic =await _context.Clinics.FirstOrDefaultAsync(x => x.Id == userDetail.ClinicId);
            var clinicName = clinic?.ClinicName ?? null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                userDetail.LastLoginDate = DateTime.Now;
                _context.Update(userDetail);
                await _context.SaveChangesAsync(cancellationToken);
                if (string.IsNullOrEmpty(userDetail.UserName)) throw new InvalidOperationException("UserName is null or empty.");
                if (string.IsNullOrEmpty(user.UserName)) throw new InvalidOperationException("UserName is null or empty.");
                var token = GenerateToken(userDetail.UserName,userDetail.ClinicId,clinicName, await _userManager.GetRolesAsync(userDetail));
                return new CreateLoginCommandResponse(
                    new LoginDto
                    {
                        UserName = user.UserName,
                        Token = token,
                        UserId = user.Id
                    }
                );
            }
            throw new UnauthorizedAccessException("Invalid credentials.");
        }




        private string GenerateToken(string userName,int? clinicId,string clinicName ,IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
            };

            if (clinicId!=null && clinicId !=0)
            {
                claims.Add(new Claim("clinicId", clinicId.ToString()));
                claims.Add(new Claim("clinicName", clinicName ?? string.Empty));
            }
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
