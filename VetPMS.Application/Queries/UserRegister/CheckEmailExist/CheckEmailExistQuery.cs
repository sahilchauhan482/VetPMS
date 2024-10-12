namespace VetPMS.Application.Queries.UserRegister.CheckEmailExist
{
    public class CheckEmailExistQuery : IRequest<CheckEmailExistQueryResponse>
    {
        public required string Email { get; set; }
        public required int ClinicId { get; set; }
    }
}
