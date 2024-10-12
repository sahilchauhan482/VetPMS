using VetPMS.Application.Queries.Clinics.GetClinic;
using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Clinics.GetClinicById
{
    public class GetClinicByIdQuery : IRequest<GetClinicByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
