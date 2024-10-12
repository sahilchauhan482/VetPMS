namespace VetPMS.Application.Commands.Patients.DeletePatient
{
    public class DeletePatientCommand : IRequest<DeletePatientCommandResponse>
    {
        public required int Id { get; set; }
        public int ClinicId { get; set; }
    }
}
