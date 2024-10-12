namespace VetPMS.Application.Query.Patients.GetPatient
{
    public class GetPatientQuery : IRequest<GetPatientQueryResponse>
    {
        public required int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
