using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Queries.Clinics.GetAllClinics
{
    public record GetAllClinicsQueryResponse(List<ClinicDto> ClinicDto);
   
}
