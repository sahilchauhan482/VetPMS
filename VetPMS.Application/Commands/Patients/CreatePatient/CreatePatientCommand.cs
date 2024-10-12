namespace VetPMS.Application.Commands.Patients.CreatePatient
{
    public class CreatePatientCommand:IRequest<CreatePatientCommandResponse>
    {
        public required int OwnerId { get; set; }
        public required string Name { get; set; }
        public required int BreedId { get; set; }
        public required int ClinicId { get; set; }
        public required DateTime DOB { get; set; }
        public required string Colour { get; set; }
       
    }
}
