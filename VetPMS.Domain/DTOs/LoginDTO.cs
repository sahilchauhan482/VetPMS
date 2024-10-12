namespace VetPMS.Domain.DTOs
{
    public class LoginDto
    {
        public required string UserId { get; set; }
        public required string UserName { get; set; }
        public required string Token { get; set; }
    }
}
