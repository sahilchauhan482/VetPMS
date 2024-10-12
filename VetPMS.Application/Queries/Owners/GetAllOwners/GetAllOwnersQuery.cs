
namespace VetPMS.Application.Queries.Owners.GetAllOwners
{
    public class GetAllOwnersQuery : IRequest<GetAllOwnersQueryResponse>
    {
        public int? ClinicId { get; set; }
    }
}
