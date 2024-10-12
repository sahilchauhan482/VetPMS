namespace VetPMS.Application.Queries.Owners.CheckOwnerPhoneExist
{
    public class CheckOwnerPhoneExistQuery:IRequest<CheckOwnerPhoneExistQueryResponse>
    {
        public required string PhoneNumber { get; set; }
        public  int? ClinicId { get; set; }
    }
}
