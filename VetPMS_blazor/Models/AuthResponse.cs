namespace VetPMS.Models
{
    public class AuthResponse
    {
        public required LoginDTO LoginDTO { get; set; }
         
    }

    public class LoginDTO
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}
