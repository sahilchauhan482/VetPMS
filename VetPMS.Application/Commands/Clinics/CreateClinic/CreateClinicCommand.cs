namespace VetPMS.Application.Commands.Clinics.CreateClinic
{
    public class CreateClinicCommand : IRequest<CreateClinicCommandResponse>
    {
        public required string ClinicName { get; set; }
        public required string ClinicEmail { get; set; }
        public required string ClinicPhone { get; set; }
        public required string ClinicAddress { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
}
