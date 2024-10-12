namespace VetPMS.Application.Queries.Owners.CheckOwnerEmailExist
{
    public class CheckOwnerEmailExistQuery:IRequest<CheckOwnerEmailExistQueryResponse>
    {
        public required string Email { get; set; }
        public  int? ClinicId { get; set; }

    }
}
