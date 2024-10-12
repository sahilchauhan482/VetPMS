namespace VetPMS.Application.Queries.UserRegister.CheckPhoneExist
{
    public class CheckPhoneExistQuery : IRequest<CheckPhoneExistQueryResponse>
    {
        public required string PhoneNumber { get; set; }
        public required int ClinicId { get; set; }
    }
}
