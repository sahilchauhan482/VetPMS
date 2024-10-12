namespace VetPMS.Application.Queries.Breed.GetBreed
{
    public class GetBreedQuery : IRequest<GetBreedQueryResponse>
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
