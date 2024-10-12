namespace VetPMS.Application.Commands.Clinics.UpdateClinic
{
    public class UpdateClinicCommand : IRequest<UpdateClinicCommandResponse>
    {
        public int Id { get; set; }
        public required string ClinicName { get; set; }
        public required string ClinicEmail { get; set; }
        public required string ClinicPhone { get; set; }
        public required string ClinicAddress { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
}
