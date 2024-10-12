namespace VetPMS.Domain.DTOs
{
    public record ResetPasswordDto()
    {
        public required string UserName { get; set; }
        public required string NewPassword { get; set; }
        public required string Token { get; set; }

    }

    

}
