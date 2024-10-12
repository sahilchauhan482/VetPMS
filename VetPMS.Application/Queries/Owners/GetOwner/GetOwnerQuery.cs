
namespace VetPMS.Application.Queries.Owners.GetOwner
{
    public record GetOwnerQuery:IRequest<GetOwnerQueryResponse>
    {
        public int Id { get; set; }
        public int? ClinicId { get; set; }

    }
}
