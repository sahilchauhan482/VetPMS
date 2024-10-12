namespace VetPMS.Models
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty; 
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ClinicId { get; set; }
        public string Role { get; set; }  = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }


}
