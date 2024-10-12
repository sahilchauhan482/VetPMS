namespace VetPMS.Application.Commands.Clinics.DeleteClinic
{
    public class DeleteClinicCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
