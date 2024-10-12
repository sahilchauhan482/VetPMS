namespace VetPMS.Models
{
    public class SetNewPasswordModel
    {
        public string UserName { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty ;
    }
}
