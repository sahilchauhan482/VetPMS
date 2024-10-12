namespace VetPMS.Application.Queries.Breed.GetAllBreeds
{
    public class GetAllBreedsQuery : IRequest<GetAllBreedsQueryResponse>
    {
        public int ClinicId { get; set; }
    }
}
