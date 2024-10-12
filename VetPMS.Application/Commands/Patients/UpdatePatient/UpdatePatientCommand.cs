namespace VetPMS.Application.Commands.Patients.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<UpdatePatientCommandResponse>
    {
        public required int Id { get; set; }
        public int ClinicId { get; set; }
        public required string Name { get; set; }
        public required int BreedId { get; set; }
        public required int OwnerId { get; set; }
        public required DateTime DOB { get; set; }
        public required string Colour { get; set; }
    }
}
