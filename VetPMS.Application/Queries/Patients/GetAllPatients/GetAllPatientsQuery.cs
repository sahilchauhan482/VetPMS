namespace VetPMS.Application.Query.Patients.GetAllPatients
{
    public class GetAllPatientsQuery : IRequest<GetAllPatientsQueryResponse>
    {
        public int ClinicId { get; set; }
    }
}
