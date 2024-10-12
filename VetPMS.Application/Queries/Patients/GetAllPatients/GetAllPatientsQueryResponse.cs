using VetPMS.Domain.DTOs;

namespace VetPMS.Application.Query.Patients.GetAllPatients
{
    public record GetAllPatientsQueryResponse(IEnumerable<PatientDto> PatientDTO);

}
