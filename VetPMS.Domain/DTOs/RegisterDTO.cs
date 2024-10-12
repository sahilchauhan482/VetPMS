using VetPMS.Domain.Entities;

namespace VetPMS.Domain.DTOs
{
    public class RegisterDto
    {
        public required string FullName { get; set; }
        public required string Gender { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }

        public static explicit operator RegisterDto(Register register)
        {
           ArgumentNullException.ThrowIfNull(register);

            return new RegisterDto
            {
                FullName = register.FullName ?? string.Empty,
                Gender = register.Gender ?? string.Empty,
                PhoneNumber = register.PhoneNumber ?? string.Empty,
                Email = register.Email ?? string.Empty,
            };
        }
    }

}
